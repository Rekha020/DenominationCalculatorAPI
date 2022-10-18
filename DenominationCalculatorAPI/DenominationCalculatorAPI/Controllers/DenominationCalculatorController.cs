using DenominationCalculatorAPI.IService;
using DenominationCalculatorAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DenominationCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenominationCalculatorController : ControllerBase
    {
        private readonly IDenominationCalculatorService _denominationCalculatorService;
        private readonly ILogger<DenominationCalculatorController> _logger;
        public DenominationCalculatorController(IDenominationCalculatorService denominationCalculatorService, ILogger<DenominationCalculatorController> logger)
        {
            _denominationCalculatorService = denominationCalculatorService;
            _logger = logger;
        }


        [HttpGet]
        [Route("GetAllDenominations")]
        public IEnumerable<int> GetAllDenominations()
        {
            var denominations = _denominationCalculatorService.GetAllDenominations();
            return denominations;

        }

        [HttpPost]
        [Route("CalculateDenominations")]
        public IActionResult CalculateDenominations([FromBody] InputCurrency inputCurrency)
        {
            try
            {
                var result = _denominationCalculatorService.CalculateDenominations(inputCurrency);
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception occured", ex);
                ModelState.Clear();
                return NoContent();
            }


        }
    }
}
