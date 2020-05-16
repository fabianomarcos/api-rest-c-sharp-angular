using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface ISpeakerRepository
    {
        Task<Speaker[]> GetAllSpeakersAsyncByName(string name, bool includeEvent);
        Task<Speaker> GetSpeakerAsyncById(int SpeakerID, bool includeEvent);
    }
}