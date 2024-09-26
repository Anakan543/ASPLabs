using Microsoft.AspNetCore.Mvc;


namespace Laborotorna3.Controllers
{
    public class CalcController : ControllerBase
    {
        private readonly CalcService _calcService;
        private readonly TimeOutput _timeOutpur;
        public CalcController(CalcService calcService, TimeOutput timeOutpur)
        {
            _calcService = calcService;
            _timeOutpur = timeOutpur;
        }
        [HttpGet("add/numbers1 = {a} numbers2 = {b}")]    
        public IActionResult Add(int a, int b)
        {
            return Ok(_calcService.Sum(a, b));
        }
        [HttpGet("sub/numbers1 = {a} numbers2 = {b}")]
        public IActionResult Substract(int a, int b)
        {
            return Ok(_calcService.Substract(a, b));
        }
        [HttpGet("mult/numbers1 = {a} numbers2 = {b}")]
        public IActionResult Multiply(int a, int b)
        {
            return Ok(_calcService.Multiply(a, b));
        }
        [HttpGet("divide/numbers1 = {a} numbers2 = {b}")]
        public IActionResult Divide(int a, int b)
        {
            try
            {
                return Ok(_calcService.Divide(a, b));
            }catch(DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("time/")]
        public IActionResult Time()
        {
            return Ok(_timeOutpur.Time());
        }
    }
}
