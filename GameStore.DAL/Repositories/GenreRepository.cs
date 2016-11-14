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
    public class GenreRepository : IRepository<Genre>
    {
        private EF.GameStore db;

        public GenreRepository(EF.GameStore context)
        {
            this.db = context;
        }

        public IEnumerable<Genre> GetAll(Expression<Func<Genre, bool>> predicate = null)
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
