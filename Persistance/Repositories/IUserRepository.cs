using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByLoginInfo(string username, string password);
        User GetByUniqueIdentifier(string username, string email);
        int Add(User user);
        int Update(User user);
        int Delete(int id);
    }
}
