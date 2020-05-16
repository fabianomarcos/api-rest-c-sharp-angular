using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProAgil.Repository;
using ProAgil.Domain;

namespace ProAgil.WebAPI.Controllers
{
    [Route("[controller")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerRepository _repository;
        private readonly IProAgilRepository _repositoryBase;

        public SpeakerController(ISpeakerRepository repository, IProAgilRepository repositoryBase)
        {
            _repository = repository;
            _repositoryBase = repositoryBase;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllSpeakersAsync(true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados!");
            }
        }

        [HttpGet("{SpeakerId}")]
        public async Task<IActionResult> Get(int SpeakerId)
        {
            try
            {
                var result = await _repository.GetSpeakerAsyncById(SpeakerId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados!");
            }
        }

        [HttpGet("getByName/{Name}")]
        public async Task<IActionResult> Get(string Name)
        {
            try
            {
                var results = await _repository.GetSpeakersAsyncByName(Name, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Speaker speakerModel)
        {
            try
            {
                _repositoryBase.Add(speakerModel);

                if (await _repositoryBase.SaveChangesAsync())
                {
                    return Created($"/speaker/{speakerModel.Id}", speakerModel);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados!");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int SpeakerId, Speaker speakerModel)
        {
            try
            {
                var response = await _repository.GetSpeakerAsyncById(SpeakerId, false);

                if (response == null) return NotFound();

                _repositoryBase.Update(speakerModel);

                if (await _repositoryBase.SaveChangesAsync())
                {
                    return Created($"/speaker/{speakerModel.Id}", speakerModel);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int SpeakerId)
        {
            try
            {
                var response = await _repository.GetSpeakerAsyncById(SpeakerId, false);

                if (response == null) return NotFound();

                _repositoryBase.Delete(response);

                if (await _repositoryBase.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados");
            }
            return BadRequest();
        }
    }
}