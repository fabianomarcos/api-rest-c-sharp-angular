using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class SpeakerRepository : ISpeaker
    {
        public readonly ProAgilContext _context;

        public SpeakerRepository(ProAgilContext context)
        {
            _context = context;
        }

        public async Task<Speaker[]> GetAllSpeakersAsyncByName(string name, bool includeEvent = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(c => c.SocialNetwork);

            if (includeEvent)
            {
                query = query
                    .Include(se => se.EventSpeakers)
                    .ThenInclude(e => e.Event);
            }

            query = query.OrderBy(s => s.Name).Where(s => s.Name.ToLowerInvariant().Contains(name));
            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerAsyncById(int SpeakerID, bool includeEvent = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialNetwork);

            if (includeEvent)
            {
                query = query
                    .Include(se => se.EventSpeakers)
                    .ThenInclude(e => e.Event);
            }

            query = query.Where(s => s.Id == SpeakerID);
            return await query.FirstOrDefaultAsync();
        }
    }
}