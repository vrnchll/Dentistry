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
    class DoctorRepository:IRepository<Doctor>
    {
        private ProjectContext db;
        public DoctorRepository(ProjectContext context)
        {
            this.db = context;
        }
        public void Create(Doctor doctor)
        {
            db.Doctors.Add(doctor);
        }

        public void Delete(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            if (doctor != null) db.Doctors.Remove(doctor);
        }

        public Doctor Get(int id)
        {
            return db.Doctors.Find(id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return db.Doctors;
        }

        public void Update(Doctor doctor)
        {
            db.Entry(doctor).State = EntityState.Modified;
        }
    }
}
