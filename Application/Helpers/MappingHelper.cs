using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class MappingHelper
    {
        public static Idea Map(this IdeaDTO src)
        {
            return new Idea()
            {
                Id = src.Id,
                Title = src.Title,
                Description = src.Description,
                UniqueCode = src.UniqueCode,
                DateCreated = DateTime.Now
            };
        }

        public static IdeaDTO Map(this Idea src)
        {
            return new IdeaDTO()
            {
                Id = src.Id,
                Title = src.Title,
                Description = src.Description,
                UniqueCode = src.UniqueCode
            };
        }
    }
}
