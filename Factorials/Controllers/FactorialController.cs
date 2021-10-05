using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factorials.Controllers
{
    [ApiController]
    public class FactorialController : ControllerBase
    {
        //private static readonly RepositoryContext _repository;
        //public FactorialController(RepositoryContext repository)
        //{
        //    _repository = repository;
        //}
        public FactorialController()
        {

        }

        [HttpGet("factorials/{n}/nearest-value")]
        public IActionResult GetNearest(int n)
        {
            return Ok();
        }

        [HttpGet("factorials/{n}")]
        public IActionResult GetFactorial(int n)
        {
            if(n < 0)
            {
                return BadRequest();
            }
            var factorial = CountFactorial(n);
            return Ok(factorial);
        }

        //[HttpGet("values/{x}")]
        //public IActionResult 
        private static long CountFactorial(int n)
        {
            return (n == 0)? 1 : n * CountFactorial(n - 1);
        }


    }
}
