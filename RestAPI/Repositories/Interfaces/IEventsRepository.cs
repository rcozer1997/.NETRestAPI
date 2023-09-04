using RestAPI.DTO.Events;
using RestAPI.Models;

namespace RestAPI.Repositories.Interfaces
{
    public interface IEventsRepository
    {
        Task<List<EventsDTO>> SearchAllEvents();
        Task<EventsDTO> SearchEventById(int id);
        Task<EventsDTO> AddEvent(EventsDTO events);
        Task<EventsDTO> UpdateEvent(EventsUpdateDTO events, int id);
        Task<bool> DeleteEvent(int id);
    }
}
