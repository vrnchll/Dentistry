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
    public class ServicesRepository:IRepository<Service>
    {
        private ProjectContext db;
        public ServicesRepository(ProjectContext context)
        {
            this.db = context;
        }
        public void Create(Service service)
        {
            db.Services.Add(service);
        }

        public void Delete(int id)
        {
            Service service = db.Services.Find(id);
            if (service != null) db.Services.Remove(service);
        }

        public Service Get(int id)
        {
            return db.Services.Find(id);
        }
        public IEnumerable<Service> Include()
        {
            return db.Services.Include(t => t.Doctors);
        }

        public IEnumerable<Service> GetAll()
        {
            return db.Services;
        }

        public void Update(Service service)
        {
            db.Entry(service).State = EntityState.Modified;
        }
    }
}
