using Factorials.Interfaces;
using Factorials.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factorials.Test.FakeRepositories
{
    public class FactorialRepositoryFake : IFactorialRepository
    {
        private readonly List<Number> _numbersRepository;

        public FactorialRepositoryFake()
        {
            _numbersRepository = new List<Number>()
            {
                new Number()
                {
                    Id = 1,
                    Value = 5,
                    Factorial = 120
                },
                new Number()
                {
                    Id = 2,
                    Value = 10,
                    Factorial = 3628800
                },
            };
        }
        public void Create(Number number)
        {
            _numbersRepository.Add(number);
        }

        public IQueryable<Number> GetAll()
        {
            return _numbersRepository as IQueryable<Number>;
        }

        public Number GetByNumber(int n)
        {
            return _numbersRepository.FirstOrDefault(number => number.Value == n);
        }
    }
}
