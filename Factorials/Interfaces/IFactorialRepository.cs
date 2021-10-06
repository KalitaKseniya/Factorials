using Factorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factorials.Interfaces
{
    public interface IFactorialRepository
    {
        IQueryable<Number> GetAll();
        Number GetByNumber(int n);
        void Create(Number number);
    }
}
