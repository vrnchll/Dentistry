using Dentistry.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext():base("DbConnectionString")
        {
            
        }
        public DbSet<Compoun> Compouns { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
