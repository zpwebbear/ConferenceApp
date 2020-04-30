using System.Threading.Tasks;
using ConferenceApp.Models;

namespace ConferenceApp.Services
{
    public interface ICountryService : IReferencialService<Country>
    {
        Task<Country> Get(string Iso);
    }
}