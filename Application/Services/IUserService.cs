using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        User Register(UserDTO user);
        User Login(UserDTO user);
        User GetUserById(int id);
    }
}
