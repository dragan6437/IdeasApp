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
                UniqueCode = Guid.NewGuid().ToString(),
                User = src.User?.Map(),
                UserId = src.UserId,
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
                UniqueCode = src.UniqueCode,
                User = src.User?.Map(),
                UserId = src.UserId
            };
        }

        public static User Map(this UserDTO src)
        {
            return new User()
            {
                Id = src.Id,
                Username = src.Username,
                Password = src.Password,
                Email = src.Email,
                FirstName = src.FirstName,
                LastName = src.LastName,
                DateCreated = DateTime.Now
            };
        }

        public static UserDTO Map(this User src)
        {
            return new UserDTO()
            {
                Id = src.Id,
                Username = src.Username,
                Password = src.Password,
                Email = src.Email,
                FirstName = src.FirstName,
                LastName = src.LastName
            };
        }
    }
}
