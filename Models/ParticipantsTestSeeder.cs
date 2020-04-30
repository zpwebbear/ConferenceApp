using Bogus;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace ConferenceApp.Models
{
    public class ParticipantsTestSeeder
    {
        public static void Initialize(ConferenceAppContext context)
        {

            var genders = context.Genders.ToList();
            var roles = context.ParticipantRoles.ToList();
            var countries = context.Countries.ToList();

            var participantFaker = new Faker<Participant>()
                .CustomInstantiator(f => new Participant())
                .RuleFor(o => o.FirstName, f => f.Person.FirstName)
                .RuleFor(o => o.LastName, f => f.Person.LastName)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.DateOfArrival, f => f.Date.Future())
                .RuleFor(o => o.DateOfDeparture, f => f.Date.Future())
                .RuleFor(o => o.CompanyName, f => f.Company.CompanyName())
                .RuleFor(o => o.PositionInCompany, f => f.Person.UserName)
                .RuleFor(o => o.Role, f => f.Random.ListItem<ParticipantRole>(roles))
                .RuleFor(o => o.Gender, f => f.Random.ListItem<Gender>(genders))
                .RuleFor(o => o.BirthDate, f => f.Date.Past(20))
                .RuleFor(o => o.Country, f => f.Random.ListItem<Country>(countries));
      
            var participants = participantFaker.Generate(100);

            foreach (Participant p in participants)
            {
                context.Participants.AddAsync(p);
            }   
            context.SaveChanges();
        }
    }
}