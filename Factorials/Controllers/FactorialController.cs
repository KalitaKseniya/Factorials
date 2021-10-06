using Factorials.Interfaces;
using Factorials.Models;
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
        private readonly IFactorialRepository _repository;
        public FactorialController(IFactorialRepository repository)
        {
            _repository =  repository;
        }

        [HttpGet("factorials/{n}/nearest-value")]
        public IActionResult GetNearest(int n)
        {
            var numbers = _repository.GetAll().Select(n => n.Value).ToList();
            var nearest = numbers.OrderBy(x => Math.Abs(x - n))
                                           ;
            int? nearest1 = (nearest.Count() > 0) ? nearest.ElementAt(0) : null;
            int? nearest2 = (nearest.Count() > 1) ? nearest.ElementAt(1) : null;

            return Ok(new { nearest1, nearest2 });
        }

        [HttpGet("factorials/{n}")]
        public IActionResult GetFactorial(int n)
        {
            if(n < 0)
            {
                return BadRequest();
            }
            var factorial = CountFactorial(n);
            
            var numberFromDb = _repository.GetByNumber(n);
            if(numberFromDb == null)
            {
                var number = new Number() { Value = n, Factorial = factorial };
                _repository.Create(number);
            }

            return Ok(factorial);
        }

        [HttpGet("values/{x}")]
        public IActionResult GetNumbersBetweenFactorial(long x)
        {
            var orderedNumbers = _repository.GetAll().OrderBy(n => n.Factorial - x).ToList();
            var nearestLeftArr = orderedNumbers.Where(n => n.Factorial - x < 0);
            var nearestRightArr = orderedNumbers.Where(n => n.Factorial - x > 0);

            int? nearestLeft = (nearestLeftArr.Count() > 0) ? nearestLeftArr.Last().Value : null;
            int? nearestRight = (nearestRightArr.Count() > 0) ? nearestRightArr.ElementAt(0).Value : null;

            return Ok(new { nearestLeft, nearestRight });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var numbers = _repository.GetAll();
            return Ok(numbers);
        }

        [HttpGet("{n}")]
        public IActionResult GetByNumber(int n)
        {
            var number = _repository.GetByNumber(n);
            if(number == null)
            {
                return NotFound();
            }
            return Ok(number);
        }

        private static long CountFactorial(int n)
        {
            return (n == 0)? 1 : n * CountFactorial(n - 1);
        }


    }
}
