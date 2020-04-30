using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceApp.Services
{
    public interface IReferencialService<T>
    {
        Task<List<T>> Get();

        Task<T> Get(int Id);
    }
}