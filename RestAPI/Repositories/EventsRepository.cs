using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Models;
using RestAPI.Repositories.Interfaces;

namespace RestAPI.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly SystemDBContext _dbContext;
        public EventsRepository(SystemDBContext systemDBContext)
        {
            _dbContext = systemDBContext;
        }
        public async Task<EventsModel> AddEvent(EventsModel events)
        {
            await _dbContext.Events.AddAsync(events);
            await _dbContext.SaveChangesAsync();

            return events;
        }

        public async Task<bool> DeleteEvent(int id)
        {
            EventsModel eventById = await SearchEventById(id);
            if (eventById == null)
            {
                throw new Exception($"Event with ID: {id} doesn't exist!");
            }

            _dbContext.Events.Remove(eventById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<EventsModel>> SearchAllEvents()
        {
            return await _dbContext.Events
                .Include(x => x.Responsible)
                .ToListAsync();
        }

        public async Task<EventsModel> SearchEventById(int id)
        {
            return await _dbContext.Events
                .Include(y => y.Responsible)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EventsModel> UpdateEvent(EventsModel events, int id)
        {
            EventsModel eventById = await SearchEventById(id);
            if (eventById == null)
            {
                throw new Exception($"User with ID: {id} doesn't exist!");
            }

            eventById.Title = events.Title;
            eventById.Description = events.Description;
            eventById.Date = events.Date;
            eventById.Participants = events.Participants;

            _dbContext.Events.Update(eventById);
            await _dbContext.SaveChangesAsync();

            return eventById;
        }
    }
}
