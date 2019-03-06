using System;
using System.Collections.Generic;
using Service.Interfaces;
using Repository.Interfaces;
using System.Linq.Expressions;
using Date.Models;

namespace Service.ImpUser
{
    public class UserService: IUserService
    {
        private IRepository<User> userRepository;
        private IRepository<User> userProfileRepository;

        public UserService(IRepository<User> userRepository, IRepository<User> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userProfileRepository = userProfileRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public User GetUser(long id)
        {
            return userRepository.Get(id);
        }
        //public UserService GetUser(string Email)
        //{
        //    return userRepository.Get(Email);
        //}

        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }
        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(long id)
        {
            //User userProfile = userProfileRepository.Get(id);
            //userProfileRepository.Remove(userProfile);
            //User user = GetUser(id);
            //userRepository.Remove(user);
           // userRepository.SaveChanges();
        }

        public User GetUserProfile(long id)
        {
            throw new NotImplementedException();
        }

        User IUserService.existEntity(Expression<Func<User, bool>> predicate)
        {
            return userRepository.existEntity(predicate);
        }
    }
}
