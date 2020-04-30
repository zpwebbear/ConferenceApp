using System.Linq;
using CountryData;

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

            var participantRoles = new ParticipantRole[]
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

            var allCountryInfo = CountryLoader.CountryInfo;

            foreach (ICountryInfo country in allCountryInfo)
            {
                var seedCountry = new Country{Name=country.Name, Iso=country.Iso, Iso3=country.Iso3, IsoNumeric=country.IsoNumeric};
                context.Countries.Add(seedCountry);
            }
            context.SaveChanges();

            var genders = new Gender[]
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
    }
}