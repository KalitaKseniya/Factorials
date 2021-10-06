using Factorials.Controllers;
using Factorials.Interfaces;
using Factorials.Models;
using Factorials.Test.FakeRepositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Linq;
using System.Net;
using Xunit;

namespace Factorials.Test
{
    public class FactorialControllerTest
    {
        Mock<IFactorialRepository> _factorialRepository;
        FactorialController _factorialController;
        const int n = 7;
        const long n_factorial = 3520;
        public FactorialControllerTest()
        {
            _factorialRepository = new Mock<IFactorialRepository>();

            _factorialController = new FactorialController(_factorialRepository.Object);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsOkResult()
        {
            var okResult = _factorialController.GetAll() as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(((int)HttpStatusCode.OK), okResult.StatusCode);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsAllItems()
        {
            var okResult = _factorialController.GetAll() as OkObjectResult;

            var items = (okResult.Value as IQueryable<Number>);
            Assert.NotNull(items);
            Assert.Equal(3, items.Count());
        }

        [Fact]
        public void GetByNumber_WhenCalled_ReturnsOkResult()
        {
            var okResult = _factorialController.GetByNumber(n) as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(((int)HttpStatusCode.OK), okResult.StatusCode);
        }

        [Fact]
        public void GetByNumber_ValidNPassed_ReturnsRightItem()
        {
            var okResult = _factorialController.GetByNumber(n) as OkObjectResult;
            
            var number = Assert.IsType<Number>(okResult.Value);
            Assert.NotNull(number);
            Assert.Equal(n, number.Value);
            Assert.Equal(n_factorial, number.Factorial);
        }

        [Fact]
        public void GetFactorial_ValidNPassed_ReturnsOk()
        {
            var okResult = _factorialController.GetFactorial(n) as OkObjectResult;
            
            //check if returns ok
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }


        [Fact]
        public void GetFactorial_InvalidNPassed_ReturnsBadRequest()
        {
            var badRequestResult = _factorialController.GetFactorial(-1) as BadRequestResult;
            Assert.NotNull(badRequestResult);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Fact]
        public void GetFactorial_ValidNPassed_ReturnsRightFactorial()
        {
            var okResult = _factorialController.GetFactorial(n) as OkObjectResult;

            var resultFactorial = Assert.IsType<long>(okResult.Value);
            Assert.Equal(resultFactorial, n_factorial);
        }

        [Fact]
        public void GetFactorial_ValidNPassed_SavesRightItemToDb()
        {
            //check if save right item to db
            var okResult = _factorialController.GetByNumber(n) as OkObjectResult;
            Assert.NotNull(okResult);
            var createdNumber = Assert.IsType<Number>(okResult.Value);
            Assert.Equal(createdNumber.Factorial, n_factorial);
        }

        [Fact]
        public void GetNearest_ReturnsOkResult()
        {
            var okObjectResult = _factorialController.GetNearest(4) as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, okObjectResult.StatusCode);
        }
        
        [Fact]
        public void GetNumbersBetweenFactorial_ReturnsOkResult()
        {
            var okObjectResult = _factorialController.GetNumbersBetweenFactorial(400) as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, okObjectResult.StatusCode);
        }

    }
}
