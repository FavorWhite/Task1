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
    public class CommentRepository : IRepository<Comment>
    {
        private EF.GameStore db;

        public CommentRepository(EF.GameStore context)
        {
            this.db = context;
        }

        public IEnumerable<Comment> GetAll(Expression<Func<Comment, bool>> predicate = null)
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