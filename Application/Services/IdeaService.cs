using Application.Helpers;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class IdeaService : IIdeaService
    {
        private readonly IIdeaRepository _ideaRepository;

        public IdeaService(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public List<IdeaDTO> GetIdeas()
        {
            var ideas = _ideaRepository.GetAll();
            return ideas.Select(x => x.Map()).ToList();
        }

        public IdeaDTO GetIdea(int id)
        {
            var idea = _ideaRepository.GetById(id);
            return idea.Map();
        }

        public bool Add(IdeaDTO ideaDTO)
        {
            var result = _ideaRepository.Insert(ideaDTO.Map());
            if (result == 1)
                return true;

            return false;
        }

        public bool Update(IdeaDTO ideaDTO)
        {
            var result = _ideaRepository.Update(ideaDTO.Map());
            if (result == 1)
                return true;

            return false;
        }

        public bool Delete(int id)
        {
            var result = _ideaRepository.Delete(id);
            if (result == 1)
                return true;

            return false;
        }
    }
}
