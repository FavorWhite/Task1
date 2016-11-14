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
    public class PlatformTypeRepository : IRepository<PlatformType>
    {
        private EF.GameStore db;

        public PlatformTypeRepository(EF.GameStore context)
        {
            this.db = context;
        }

        public IEnumerable<PlatformType> GetAll(Expression<Func<PlatformType, bool>> predicate = null)
        {
            return db.PlatformTypes;
        }

        public PlatformType Get(int id)
        {
            return db.PlatformTypes.Find(id);
        }

        public void Create(PlatformType item)
        {
            db.PlatformTypes.Add(item);
        }

        public void Update(PlatformType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }


        public void Delete(int id)
        {
            PlatformType item = db.PlatformTypes.Find(id);
            if (item != null)
                db.PlatformTypes.Remove(item);
        }
    }
}
