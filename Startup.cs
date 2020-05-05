using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConferenceApp.Data;
using Microsoft.EntityFrameworkCore;
using ConferenceApp.Models;
using Microsoft.Data.SqlClient;
using ConferenceApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;

namespace ConferenceApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("ConferenceAppDatabase"));
            builder.UserID = Configuration["DbUserID"];
            builder.Password = Configuration["DbPassword"];

            services.AddDbContext<ConferenceAppContext>(options =>
                options.UseSqlServer(builder.ConnectionString));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ConferenceAppContext>();
            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                    {
                        options.Conventions.AuthorizeFolder("/");
                    });
            services.AddServerSideBlazor();
            services.AddControllers();
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            services.AddScoped(typeof(IReferencialService<>), typeof(RefereincialService<>));
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IParticipantRoleService, ParticipantRoleService>();
            services.AddTransient<CountryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
