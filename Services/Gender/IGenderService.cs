using System.Threading.Tasks;
using ConferenceApp.Models;

namespace ConferenceApp.Services
{
    public interface IGenderService : IReferencialService<Gender>
    {
        Task<Gender> Get(string genderValue);
    }
}