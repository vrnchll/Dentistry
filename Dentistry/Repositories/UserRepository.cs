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
    public class UserRepository : IRepository<User>
    {
        private ProjectContext db;
        public UserRepository(ProjectContext context)
        {
            this.db = context;
        }
        public void Create(User user)
        {
            db.Users.Add(user);
        }
        public void Attach(User user)
        {
            db.Users.Attach(user);
        }
        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null) db.Users.Remove(user);
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
    }
}
