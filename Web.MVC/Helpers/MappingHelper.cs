using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.MVC.Models;

namespace Web.MVC.Helpers
{
    public static class MappingHelper
    {
        public static IdeaDTO MapToIdeaDTO(this AddIdeaViewModel src)
        {
            return new IdeaDTO()
            {
                Title = src.Title,
                Description = src.Description
            };
        }

        public static IdeaViewModel MapToIdeaVm(this IdeaDTO src)
        {
            return new IdeaViewModel()
            {
                Id = src.Id,
                Title = src.Title,
                Description = src.Description,
                UniqueCode = src.UniqueCode,
                User = src.User
            };
        }

        public static List<IdeaViewModel> MapToIdeaVm(this List<IdeaDTO> src)
        {
            return src.Select(x => x.MapToIdeaVm()).ToList();
        }

        public static UserDTO MapToUserDTO(this LoginUserViewModel src)
        {
            return new UserDTO()
            {
                Username = src.Username,
                Password = src.Password
            };
        }

        public static UserDTO MapToUserDTO(this RegisterUserViewModel src)
        {
            return new UserDTO()
            {
                Username = src.Username,
                Password = src.Password,
                Email = src.Email,
                FirstName = src.FirstName,
                LastName = src.LastName
            };
        }
    }
}
