using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_DAL.EF;
using Task1_DAL.Entities;
using Task1_DAL.Intefaces;

namespace Task1_DAL.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private GameStore db;

        public GameRepository(GameStore context)
        {
            this.db = context;
        }

        public IEnumerable<Game> GetAll()
        {
            return db.Games;
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
