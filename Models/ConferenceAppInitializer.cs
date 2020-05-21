using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceApp.Authorization;
using CountryData;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ConferenceApp.Models
{
    public class ConferenceAppInitializer
    {
        // I guess this initializer can be improoved
        public static void Initialize(ConferenceAppContext context)
        {
            context.Database.EnsureCreated();

            if(context.ParticipantRoles.Any())
            {
                return;
            }

            ParticipantRole[] participantRoles = new ParticipantRole[]
            {
                new ParticipantRole{RoleName="Speaker"},
                new ParticipantRole{RoleName="Administrator"},
                new ParticipantRole{RoleName="Listener"},
            };

            foreach (ParticipantRole pr in participantRoles)
            {
                context.ParticipantRoles.Add(pr);
            }   
            context.SaveChanges();

            IReadOnlyList<ICountryInfo> allCountryInfo = CountryLoader.CountryInfo;

            foreach (ICountryInfo country in allCountryInfo)
            {
                Country seedCountry = new Country{Name=country.Name, Iso=country.Iso, Iso3=country.Iso3, IsoNumeric=country.IsoNumeric};
                context.Countries.Add(seedCountry);
            }
            context.SaveChanges();

            Gender[] genders = new Gender[]
            {
                new Gender{Value="Male"},
                new Gender{Value="Female"},
            };

            foreach (Gender g in genders)
            {
                context.Genders.Add(g);
            }   
            context.SaveChanges();

        }

        public static async void SeedUsers(UserManager<IdentityUser> userManager, IConfiguration Configuration)
        {
            Console.WriteLine("Seed users");
            var superadminEmail = Configuration["Superadmin:Email"];
            var superadminPassword = Configuration["Superadmin:Password"];
            var existedSuperAdmin = await userManager.FindByEmailAsync(superadminEmail);
            if (existedSuperAdmin == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = superadminEmail,
                    Email = superadminEmail
                };

                IdentityResult result = userManager.CreateAsync(user, superadminPassword).Result;
                Console.WriteLine("Result success => {0}", result.Succeeded);
                if (result.Succeeded)
                {
                    IdentityResult r = await userManager.AddToRoleAsync(user, Roles.SuperAdmin);
                    Console.WriteLine("Add to role success => {0}", r.Succeeded);
                }
            }
        }
    }
}