using AcmeWidgetSignUp.Domain;
using AcmeWidgetSignUp.Dtos;
using AcmeWidgetSignUp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeWidgetSignUp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterestedPersonsController : ControllerBase
    {
        private readonly ILogger<InterestedPersonsController> _logger;
        private readonly IInterestedPersonRepository _interestedPersonRepository;

        public InterestedPersonsController(ILogger<InterestedPersonsController> logger, IInterestedPersonRepository interestedPersonRepository)
        {
            _logger = logger;
            _interestedPersonRepository = interestedPersonRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterestedPerson>>> Get()
        {
            try
            {
                var employeeActivities = _interestedPersonRepository.GetInterestedPersons();

                return Ok(employeeActivities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception thrown getting Interested Persons");
                return BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InterestedPerson interestedPerson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _interestedPersonRepository.AddInterestedPerson(interestedPerson);

                    return Ok();
                }
                else
                {
                    _logger.LogError("Error saving employee activity. Model in bad state.");
                    return BadRequest("Error saving employee activity.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception thrown getting Interested Persons");
                return BadRequest(ex);
            }
        }
    }
}
