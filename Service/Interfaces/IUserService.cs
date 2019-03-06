using Date.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(long id);
        //UserService GetUser(string email);
        User GetUserProfile(long id);

        User existEntity(Expression<Func<User, bool>> predicate);
    }
}
