using Application.Helpers;
using Domain.Models;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User Login(UserDTO user)
        {
            return _userRepository.GetByLoginInfo(user.Username, user.Password);
        }

        public User Register(UserDTO user)
        {
            var existingUser = _userRepository.GetByUniqueIdentifier(user.Username, user.Email);
            if(existingUser == null)
            {
                _userRepository.Add(user.Map());
                return Login(user);
            }

            return null;
        }
    }
}
