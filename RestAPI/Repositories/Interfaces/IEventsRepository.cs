using RestAPI.Models;

namespace RestAPI.Repositories.Interfaces
{
    public interface IEventsRepository
    {
        Task<List<EventsModel>> SearchAllEvents();
        Task<EventsModel> SearchEventById(int id);
        Task<EventsModel> AddEvent(EventsModel events);
        Task<EventsModel> UpdateEvent(EventsModel events, int id);
        Task<bool> DeleteEvent(int id);
    }
}
