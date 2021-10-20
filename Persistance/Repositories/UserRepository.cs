using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdeasDbContext _dbContext;

        public UserRepository(IdeasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetByLoginInfo(string username, string password)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public User GetByUniqueIdentifier(string username, string email)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Username == username || x.Email == email);
        }

        public int Add(User user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Update(User user)
        {
            var entity = _dbContext.Users.FirstOrDefault(x => x.Id == user.Id);

            entity.Password = user.Password;
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;

            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
