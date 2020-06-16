using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;
using ProAgil.WebAPI.DTOs;

namespace ProAgil.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _repository;
        private readonly IProAgilRepository _repositoryBase;
        private readonly IMapper _mapper;
        public EventController(
            IEventRepository repository,
            IProAgilRepository repositoryBase,
            IMapper mapper
        )
        {
            _repository = repository;
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Event[] events = await _repository.GetAllEventsAsync(true);

                IEnumerable<EventDto> results = _mapper.Map<EventDto[]>(events);
                
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco de dados! {ex.Message}");
            }
        }

        [HttpGet("{EventId}")]
        public async Task<IActionResult> Get(int EventId)
        {
            try
            {
                Event result = await _repository.GetEventAsyncById(EventId, true);

                EventDto resultEvent = _mapper.Map<EventDto>(result);

                return Ok(resultEvent);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }
        }

        [HttpGet("getByTheme/{theme}")]
        public async Task<IActionResult> Get(string theme)
        {
            try
            {
                Event[] eventTheme = await _repository.GetAllEventsAsyncByThema(theme, true);

                IEnumerable<EventDto> results = _mapper.Map<EventDto[]>(eventTheme);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventDto eventModel)
        {
            try
            {
                Event newEvent = _mapper.Map<Event>(eventModel);
                
                _repositoryBase.Add(newEvent);

                if (await _repositoryBase.SaveChangesAsync())
                {
                    return Created($"/event/{eventModel.Id}", _mapper.Map<EventDto>(newEvent));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }
            return BadRequest();
        }

        [HttpPut("{EventId}")]
        public async Task<IActionResult> Put(int EventId, EventDto eventModel)
        {
            try
            {
                Event eventEdited = await _repository.GetEventAsyncById(EventId, false);

                if (eventEdited == null) return NotFound();

                _mapper.Map(eventModel, eventEdited);

                _repositoryBase.Update(eventEdited);

                if (await _repositoryBase.SaveChangesAsync())
                {
                    return Created($"/event/{eventModel.Id}", _mapper.Map<EventDto>(eventEdited));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }
            return BadRequest();
        }

        [HttpDelete("{EventId}")]
        public async Task<IActionResult> Delete(int EventId)
        {
            try
            {
                var response = await _repository.GetEventAsyncById(EventId, false);

                if (response == null) return NotFound();

                _repositoryBase.Delete(response);

                if (await _repositoryBase.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }
            return BadRequest();
        }
    }
}