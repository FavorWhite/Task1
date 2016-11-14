using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entities;

namespace GameStore.DAL.Intefaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
