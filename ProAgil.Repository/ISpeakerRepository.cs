using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface ISpeakerRepository
    {
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvent);
        Task<Speaker[]> GetSpeakersAsyncByName(string name, bool includeEvent);
        Task<Speaker> GetSpeakerAsyncById(int SpeakerId, bool includeEvent);
    }
}