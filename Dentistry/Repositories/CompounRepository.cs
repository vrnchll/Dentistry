using Dentistry.Context;
using Dentistry.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Repositories
{
    public class CompounRepository:IRepository<Compoun>
    {
        private ProjectContext db;
        public CompounRepository(ProjectContext context)
        {
            this.db = context;
        }
        public void Create(Compoun compoun)
        {
            db.Compouns.Add(compoun);
        }

        public void Delete(int id)
        {
            Compoun compoun = db.Compouns.Find(id);
            if (compoun != null) db.Compouns.Remove(compoun);
        }

        public Compoun Get(int id)
        {
            return db.Compouns.Find(id);
        }

        public IEnumerable<Compoun> GetAll()
        {
            return db.Compouns;
        }

        public void Update(Compoun compoun)
        {
            db.Entry(compoun).State = EntityState.Modified;
        }
    }
}
