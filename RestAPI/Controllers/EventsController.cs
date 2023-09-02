using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using RestAPI.Repositories;
using RestAPI.Repositories.Interfaces;

namespace RestAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository _eventsRepository;
        public EventsController(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<EventsModel>>> SearchAllEvents()
        {
            List<EventsModel> events = await _eventsRepository.SearchAllEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EventsModel>>> SearchEventsById(int id)
        {
            EventsModel events = await _eventsRepository.SearchEventById(id);
            return Ok(events);
        }

        [HttpPost]
        public async Task<ActionResult<EventsModel>> RegisterEvent([FromBody] EventsModel eventsModel)
        {
            EventsModel events = await _eventsRepository.AddEvent(eventsModel);

            return Ok(events);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EventsModel>> Update([FromBody] EventsModel eventsModel, int id)
        {
            eventsModel.Id = id;
            EventsModel events = await _eventsRepository.UpdateEvent(eventsModel, id);

            return Ok(events);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EventsModel>> Delete(int id)
        {

            Boolean deletedEvent = await _eventsRepository.DeleteEvent(id);

            return Ok(deletedEvent);

        }
    }
}
