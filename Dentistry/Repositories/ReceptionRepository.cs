using Dentistry.Context;
using Dentistry.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Repositories
{
   public class ReceptionRepository:IRepository<Reception>
    {
        private ProjectContext db;
        public ReceptionRepository(ProjectContext context)
        {
            this.db = context;
        }
        public void Create(Reception reception)
        {
            db.Receptions.Add(reception);
        }

        public void Delete(int id)
        {
            Reception reception = db.Receptions.Find(id);
            if (reception != null) db.Receptions.Remove(reception);
        }

        public Reception Get(int id)
        {
            return db.Receptions.Find(id);
        }

        public IEnumerable<Reception> GetAll()
        {
            return db.Receptions;
        }

        public void Update(Reception reception)
        {
            db.Receptions.AddOrUpdate(reception);
        }
    }
}
