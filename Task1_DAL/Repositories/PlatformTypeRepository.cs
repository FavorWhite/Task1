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
    public class PlatformTypeRepository : IRepository<PlatformType>
    {
        private GameStore db;

        public PlatformTypeRepository(GameStore context)
        {
            this.db = context;
        }

        public IEnumerable<PlatformType> GetAll()
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
