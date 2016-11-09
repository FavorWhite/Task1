using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entities;

namespace GameStore.DAL.Intefaces
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
