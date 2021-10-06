using Factorials.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factorials.Models
{
    public class FactorialRepository: IFactorialRepository
    {
        private readonly RepositoryContext _repository;
        public FactorialRepository(RepositoryContext repository)
        {
            _repository = repository;
        }

        public IQueryable<Number> GetAll()
        {
            return _repository.Numbers;
        }

        public Number GetByNumber(int n)
        {
            return _repository.Numbers.FirstOrDefault(number => number.Value == n);
        }

        public void Create(Number number)
        {
            _repository.Numbers.Add(number);
            _repository.SaveChanges();
        }
    }
}
