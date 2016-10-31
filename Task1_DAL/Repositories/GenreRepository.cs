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
    public class GenreRepository : IRepository<Genre>
    {
        private GameStore db;

        public GenreRepository(GameStore context)
        {
            this.db = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres;
        }

        public Genre Get(int id)
        {
            return db.Genres.Find(id);
        }

        public void Create(Genre item)
        {
            db.Genres.Add(item);
        }

        public void Update(Genre item)
        {
            db.Entry(item).State = EntityState.Modified;
        }


        public void Delete(int id)
        {
            Genre item = db.Genres.Find(id);
            if (item != null)
                db.Genres.Remove(item);
        }
    }
}
