using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class EventRepository : IEventRepository
    {
        public readonly ProAgilContext _context;
        public EventRepository(ProAgilContext context)
        {
            _context = context;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers)
        {

            IQueryable<Event> query = _context.Events
                .Include(c => c.Lots)
                .Include(c => c.SocialNetworks);

            if (includeSpeakers)
            {
                query = query
                    .Include(se => se.EventSpeakers)
                    .ThenInclude(s => s.Speaker);
            }
            query = query.OrderBy(c => c.DateEvent);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsAsyncByThema(string theme, bool includeSpeakers)
        {
            IQueryable<Event> query = _context.Events
                .Include(c => c.Lots)
                .Include(c => c.SocialNetworks);

            if (includeSpeakers)
            {
                query = query
                    .Include(se => se.EventSpeakers)
                    .ThenInclude(s => s.Speaker);
            }

            query = query
                .OrderBy(c => c.DateEvent)
                .Where(c => c.Theme.ToLowerInvariant().Contains(theme));

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventAsyncById(int EventId, bool includeSpeakers)
        {
            IQueryable<Event> query = _context.Events
                .Include(c => c.Lots)
                .Include(c => c.SocialNetworks);

            if (includeSpeakers)
            {
                query = query
                    .Include(es => es.EventSpeakers)
                    .ThenInclude(s => s.Speaker);
            }

            query = query
                .OrderBy(c => c.DateEvent)
                .Where(c => c.Id == EventId);

            return await query.FirstOrDefaultAsync();
        }
    }
}