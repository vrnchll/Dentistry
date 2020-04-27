using Dentistry.Context;
using Dentistry.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Services
{
    class UnitOfWork : IDisposable
    {
        private ProjectContext db = new ProjectContext();
        private CompounRepository compounRepository;
        private DoctorRepository doctorRepository;
        private PatientRepository patientRepository;
        private ReceptionRepository receptionRepository;
        private ServicesRepository servicesRepository;
        private UserRepository userRepository;
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public CompounRepository Compoun
        {
            get
            {
                if (compounRepository == null)
                    compounRepository = new CompounRepository(db);
                return compounRepository;
            }
        }

        public DoctorRepository Doctor
        {
            get
            {
                if (doctorRepository == null)
                    doctorRepository = new DoctorRepository(db);
                return doctorRepository;
            }
        }

        public PatientRepository Patient
        {
            get
            {
                if (patientRepository == null)
                    patientRepository = new PatientRepository(db);
                return patientRepository;
            }
        }

        public ReceptionRepository Reception
        {
            get
            {
                if (receptionRepository == null)
                    receptionRepository = new ReceptionRepository(db);
                return receptionRepository;
            }
        }

        public ServicesRepository Service
        {
            get
            {
                if (servicesRepository == null)
                    servicesRepository = new ServicesRepository(db);
                return servicesRepository;
            }
        }

        public  UserRepository User
        {
            get
            {
                if (userRepository == null)
                   userRepository = new UserRepository(db);
                return userRepository;
            }
        }
    }
}
