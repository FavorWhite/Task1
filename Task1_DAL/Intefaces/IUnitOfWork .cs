using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_DAL.Entities;

namespace Task1_DAL.Intefaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Game> Game { get; }
        IRepository<Comment> Comment { get; }
        IRepository<Genre> Genre { get; }
        IRepository<PlatformType> PlatformType { get; }
        void Save();
    }
}
