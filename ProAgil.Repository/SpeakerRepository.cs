using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class SpeakerRepository : ISpeakerRepository
    {
        public readonly ProAgilContext _context;

        public SpeakerRepository(ProAgilContext context)
        {
            _context = context;
        }

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvent = false)
        {
            IQueryable<Speaker> query = _context.Speakers;

            query = query.OrderBy(speaker => speaker.Name);
            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetSpeakersAsyncByName(string name, bool includeEvent = false)
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

        public async Task<Speaker> GetSpeakerAsyncById(int SpeakerId, bool includeEvent = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialNetwork);

            if (includeEvent)
            {
                query = query
                    .Include(se => se.EventSpeakers)
                    .ThenInclude(e => e.Event);
            }

            query = query.Where(s => s.Id == SpeakerId);
            return await query.FirstOrDefaultAsync();
        }
    }
}