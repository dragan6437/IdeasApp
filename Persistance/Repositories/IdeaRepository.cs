using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class IdeaRepository : IIdeaRepository
    {
        private readonly IdeasDbContext _dbContext;

        public IdeaRepository(IdeasDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Idea> GetAll()
        {
            return _dbContext.Ideas.Include(x => x.User);
        }

        public Idea GetById(int id)
        {
            return _dbContext.Ideas.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Idea idea)
        {
            _dbContext.Ideas.Add(idea);
            return _dbContext.SaveChanges();
        }

        public int Update(Idea idea)
        {
            var entity = _dbContext.Ideas.FirstOrDefault(x => x.Id == idea.Id);

            entity.Title = idea.Title;
            entity.Description = idea.Description;

            _dbContext.Ideas.Update(entity);
            return _dbContext.SaveChanges();
        }
        public int Delete(int id)
        {
            var idea = _dbContext.Ideas.FirstOrDefault(x => x.Id == id);
            if (idea == null)
                return -1;

            _dbContext.Ideas.Remove(idea);
            return _dbContext.SaveChanges();
        }
    }
}
