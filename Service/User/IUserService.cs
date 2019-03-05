using System;
using Date;
using System.Collections.Generic;
using System.Text;

namespace Service.User
{
    public interface IUserService
    {
        IEnumerable<UserService> GetUsers();
        UserService GetUser(long id);
        void InsertUser(UserService user);
        void UpdateUser(UserService user);
        void DeleteUser(long id);

        UserService GetUserProfile(long id);
    }
}
