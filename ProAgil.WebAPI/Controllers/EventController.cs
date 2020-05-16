using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _repository;
        private readonly IProAgilRepository _repositoryBase;
        public EventController(IEventRepository repository, IProAgilRepository repositoryBase)
        {
            _repository = repository;
            _repositoryBase = repositoryBase;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllEventsAsync(true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }
        }

        [HttpGet("{EventId}")]
        public async Task<IActionResult> Get(int EventId)
        {
            try
            {
                var results = await _repository.GetEventAsyncById(EventId, true);
                return Ok(results);
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
                var results = await _repository.GetAllEventsAsyncByThema(theme, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event eventModel)
        {
            try
            {
                _repositoryBase.Add(eventModel);

                if (await _repositoryBase.SaveChangesAsync())
                {
                    return Created($"/event/{eventModel.Id}", eventModel);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int EventId, Event eventModel)
        {
            try
            {
                var response = await _repository.GetEventAsyncById(EventId, false);

                if (response == null) return NotFound();

                _repositoryBase.Update(eventModel);

                if (await _repositoryBase.SaveChangesAsync())
                {
                    return Created($"/event/{eventModel.Id}", eventModel);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }
            return BadRequest();
        }

        [HttpDelete]
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