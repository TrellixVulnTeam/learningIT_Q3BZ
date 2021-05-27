using Learning_IT.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Learning_IT.IRepositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int userId);
        void InsertUser(User user);
        void DeleteUser(int StudentId);
        void UpdateUser(User user);
        void Save();
    }
}
