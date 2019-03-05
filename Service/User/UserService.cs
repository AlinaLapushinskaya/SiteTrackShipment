using System;
using Date;
using Repository;
using System.Collections.Generic;
using System.Text;
using Service.User;
using Repository.Repository;

namespace Service.User
{
    public class UserService:IUserService
    {
        private IRepository<UserService> userRepository;
        private IRepository<UserService> userProfileRepository;

        public UserService(IRepository<UserService> userRepository, IRepository<UserService> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userProfileRepository = userProfileRepository;
        }

        public IEnumerable<UserService> GetUsers()
        {
            return userRepository.GetAll();
        }

        public UserService GetUser(long id)
        {
            return userRepository.Get(id);
        }

        public void InsertUser(UserService user)
        {
            userRepository.Insert(user);
        }
        public void UpdateUser(UserService user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(long id)
        {
            UserService userProfile = userProfileRepository.Get(id);
            userProfileRepository.Remove(userProfile);
            UserService user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }

        public UserService GetUserProfile(long id)
        {
            throw new NotImplementedException();
        }
    }
}
