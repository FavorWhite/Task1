using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entities;
using GameStore.DAL.Intefaces;
using GameStore.DAL.EF;

namespace GameStore.DAL.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private EF.GameStore db;

        public GameRepository(EF.GameStore context)
        {
            this.db = context;
        }

        public IEnumerable<Game> GetAll(Expression<Func<Game, bool>> predicate=null)
        {
            if (predicate==null)
            {
                return db.Games;
            }
            return db.Games.Where(predicate);
        }

        public Game Get(int id)
        {
            return db.Games.Find(id);
        }

        public void Create(Game item)
        {
            db.Games.Add(item);
        }

        public void Update(Game item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

       
        public void Delete(int id)
        {
            Game item = db.Games.Find(id);
            if (item != null)
                db.Games.Remove(item);
        }
    }
}
