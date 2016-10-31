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
    public class CommentRepository : IRepository<Comment>
    {
        private GameStore db;

        public CommentRepository(GameStore context)
        {
            this.db = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments;
        }

        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }

        public void Create(Comment item)
        {
            db.Comments.Add(item);
        }

        public void Update(Comment item)
        {
            db.Entry(item).State = EntityState.Modified;
        }


        public void Delete(int id)
        {
            Comment item = db.Comments.Find(id);
            if (item != null)
                db.Comments.Remove(item);
        }
    }
}