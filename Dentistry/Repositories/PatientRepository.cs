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
    class PatientRepository
    {
        private ProjectContext db;
        public PatientRepository(ProjectContext context)
        {
            this.db = context;
        }
        public void Create(Patient patient)
        {
            db.Patients.Add(patient);
        }

        public void Delete(int id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient != null) db.Patients.Remove(patient);
        }

        public Patient Get(int id)
        {
            return db.Patients.Find(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return db.Patients;
        }

        public void Update(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
        }
    }
}
