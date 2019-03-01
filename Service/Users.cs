using System;
using Date;
using Repository;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class Users:IUser
    {
        private IRepository<Users> userRepository;
        private IRepository<Users> userProfileRepository;

        public Users(IRepository<Users> userRepository, IRepository<Users> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userProfileRepository = userProfileRepository;
        }

        public IEnumerable<Users> GetUsers()
        {
            return userRepository.GetAll();
        }

        public Users GetUser(long id)
        {
            return userRepository.Get(id);
        }

        public void InsertUser(Users user)
        {
            userRepository.Insert(user);
        }
        public void UpdateUser(Users user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(long id)
        {
            Users userProfile = userProfileRepository.Get(id);
            userProfileRepository.Remove(userProfile);
            Users user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }

        public Users GetUserProfile(long id)
        {
            throw new NotImplementedException();
        }
    }
}
