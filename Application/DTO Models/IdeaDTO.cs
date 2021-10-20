using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class IdeaDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UniqueCode { get; set; }
        public UserDTO User { get; set; }
        public int UserId { get; set; }
    }
}
