using Learning_IT.IRepositories;
using Learning_IT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Repositories
{
    public class UserRepository : IUserRepository,IDisposable
    {
        private MyContext myContext;

        public UserRepository(MyContext context)
        {
            this.myContext = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return myContext.Users.ToList();
        }

        public User GetUserById(int Id)
        {
            return myContext.Users.Find(Id);
        }

        public void InsertUser(User user)
        {
            myContext.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            User user = myContext.Users.Find(userId);
            myContext.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            myContext.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            myContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    myContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
