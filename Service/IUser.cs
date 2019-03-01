using System;
using Date;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IUser
    {
        IEnumerable<Users> GetUsers();
        Users GetUser(long id);
        void InsertUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(long id);

        Users GetUserProfile(long id);
    }
}
