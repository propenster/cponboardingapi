using AutoMapper;
using CPOnboardingAPI.Data;
using CPOnboardingAPI.Dtos.Requests;
using CPOnboardingAPI.Dtos.Responses;
using CPOnboardingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CPOnboardingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmployeerController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public EmployeerController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("templates/questiontypes")]
        [SwaggerOperation(Summary = "Get all types")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<string>))]
        public async Task<IActionResult> GetQuestionTypes()
        {
            return Ok(new List<string> { "paragraph", "yesorno", "dropdown", "date", "number"});
        }

        [HttpPost("templates")]
        [SwaggerOperation(Summary = "Create a new application template")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationTemplateResponse))]
        public async Task<IActionResult> CreateTemplate([FromBody] ApplicationTemplateRequest request)
        {
            var requestObj = _mapper.Map<ApplicationTemplate>(request);
            var result = await _repository.CreateTemplate(requestObj);
            return Ok(_mapper.Map<ApplicationTemplateResponse>(result));
        }

        [HttpGet("templates")]
        [SwaggerOperation(Summary = "Get all application templates in the DB")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ApplicationTemplateResponse>))]
        public async Task<IActionResult> GetAllTemplates()
        {
            return Ok(_mapper.Map<IEnumerable<ApplicationTemplateResponse>>(await _repository.GetAllTemplates()));
        }

        [HttpGet("templates/{id}")]
        [SwaggerOperation(Summary = "Get an application template")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationTemplateResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTemplate(string id)
        {
            var result = await _repository.GetTemplateById(id);
            if (result is null) return NotFound();

            return Ok(_mapper.Map<ApplicationTemplateResponse>(result));
        }

        [HttpPut("templates/{id}")]
        [SwaggerOperation(Summary = "Update an application template")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationTemplateResponse))]
        public async Task<IActionResult> UpdateTemplate(string id, [FromBody] ApplicationTemplateRequest request)
        {
            var requestObj = _mapper.Map<ApplicationTemplate>(request);
            var result = await _repository.UpdateTemplate(id, requestObj);
            return Ok(_mapper.Map<ApplicationTemplateResponse>(result));
        }

        [HttpDelete("templates/{id}")]
        [SwaggerOperation(Summary = "Delete an application template")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteTemplate(string id)
        {
            await _repository.DeleteTemplate(id);
            return NoContent();
        }

    }
}
