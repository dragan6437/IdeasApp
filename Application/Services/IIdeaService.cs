using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IIdeaService
    {
        List<IdeaDTO> GetIdeas();
        IdeaDTO GetIdea(int id);
        bool Add(IdeaDTO entity);
        bool Update(IdeaDTO entity);
        bool Delete(int id);
    }
}
