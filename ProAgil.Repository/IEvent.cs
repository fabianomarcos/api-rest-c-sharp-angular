using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IEvent
    {
        Task<Event[]> GetAllEventsAsyncByThema(string thema, bool includeSpeakers);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers);
        Task<Event> GetEventAsyncById(int EventId, bool includeSpeakers);
    }
}