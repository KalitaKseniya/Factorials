using Factorials.Models;
using System.Linq;

namespace Factorials.Interfaces
{
    public interface IFactorialRepository
    {
        IQueryable<Number> GetAll();
        Number GetByNumber(int n);
        void Create(Number number);
    }
}
