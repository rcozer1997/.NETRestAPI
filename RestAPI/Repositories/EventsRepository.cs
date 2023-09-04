using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.DTO.Events;
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

        public async Task<EventsDTO> AddEvent(EventsDTO events)
        {
            List<UserModel> participants = new List<UserModel>();
            foreach (var email in events.ParticipantsEmails)
            {
                UserModel participant = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
                if (participant == null)
                {
                    throw new Exception("Participant not found!");
                }
                participants.Add(participant);
            }

            UserModel responsible = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == events.ResponsibleEmail);
            if (responsible == null)
            {
                throw new Exception("Responsible user not found!");
            }

            EventsModel eventModel = new EventsModel()
            {
                Title = events.Title,
                Description = events.Description,
                Date = events.Date,
                Responsible = responsible
            };
            await _dbContext.Events.AddAsync(eventModel);

            foreach (var participant in participants)
            {
                EventsParticipantsModel eventsParticipantsModel = new EventsParticipantsModel()
                {
                    Event = eventModel,
                    User = participant
                };
                await _dbContext.EventsParticipants.AddAsync(eventsParticipantsModel);
            }

            await _dbContext.SaveChangesAsync();

            return events;
        }

        public async Task<bool> DeleteEvent(int id)
        {
            EventsModel eventById = await SearchEventModelById(id);
            if (eventById == null)
            {
                throw new Exception($"Event with ID: {id} doesn't exist!");
            }

            _dbContext.Events.Remove(eventById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<EventsDTO>> SearchAllEvents()
        {   
            List<EventsModel> eventModel = await _dbContext.Events
                .Include(x => x.Responsible)
                .ToListAsync();

            return eventModel.Select(x => new EventsDTO()
            {
                Title = x.Title,
                Description = x.Description,
                Date = x.Date,
                ResponsibleEmail = x.Responsible.Email,
                ParticipantsEmails = x.Participants.Select(x => x.User.Email).ToList()
            }).ToList();
        }

        public async Task<EventsDTO> SearchEventById(int id)
        {
            var eventModel = await SearchEventModelById(id);

            return new EventsDTO()
            {
                Title = eventModel.Title,
                Description = eventModel.Description,
                Date = eventModel.Date,
                ResponsibleEmail = eventModel.Responsible.Email,
                ParticipantsEmails = eventModel.Participants.Select(x => x.User.Email).ToList()
            };
        }

        private async Task<EventsModel> SearchEventModelById(int id)
        {
            EventsModel eventModel = await _dbContext.Events
            .Include(y => y.Responsible)
            .Include(y => y.Participants)
            .FirstOrDefaultAsync(x => x.Id == id);

            if (eventModel == null)
            {
                throw new Exception("Event not found!");
            }

            return eventModel;
        }

        public async Task<EventsDTO> UpdateEvent(EventsUpdateDTO events, int id)
        {
            EventsModel eventById = await SearchEventModelById(id);
            if (eventById == null)
            {
                throw new Exception($"User with ID: {id} doesn't exist!");
            }

            eventById.Title = events.Title;
            eventById.Description = events.Description;
            eventById.Date = events.Date;

            _dbContext.Events.Update(eventById);
            await _dbContext.SaveChangesAsync();

            return new EventsDTO()
            {
                Title = eventById.Title,
                Description = eventById.Description,
                Date = eventById.Date,
                ResponsibleEmail = eventById.Responsible.Email,
                ParticipantsEmails = eventById.Participants.Select(x => x.User.Email).ToList()
            };
        }
    }
}
