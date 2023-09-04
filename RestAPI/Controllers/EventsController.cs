using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RestAPI.DTO.Events;
using RestAPI.Models;
using RestAPI.Repositories;
using RestAPI.Repositories.Interfaces;

namespace RestAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository _eventsRepository;
        public EventsController(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        [HttpGet("search_all")]
        public async Task<ActionResult<List<EventsDTO>>> SearchAllEvents()
        {
            List<EventsDTO> events = await _eventsRepository.SearchAllEvents();

            return Ok(events);
        }

        [HttpGet("search_by_id/{id}")]
        public async Task<ActionResult<List<EventsDTO>>> SearchEventsById(int id)
        {
            EventsDTO events = await _eventsRepository.SearchEventById(id);

            return Ok(events);
        }

        [HttpPost("register")]
        public async Task<ActionResult<EventsDTO>> RegisterEvent([FromBody] EventsDTO events)
        {   
            if(events.ParticipantsEmails.Count < 1)
            {
                throw new Exception("It must have at least one participant!");
            }
            EventsDTO result = await _eventsRepository.AddEvent(events);

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<EventsDTO>> Update([FromBody] EventsUpdateDTO events, int id)
        {         
            EventsDTO result = await _eventsRepository.UpdateEvent(events, id);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<EventsDTO>> Delete(int id)
        {
            bool deletedEvent = await _eventsRepository.DeleteEvent(id);

            return Ok(deletedEvent);
        }
    }
}
