using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowBackend.Core.Models.Responses
{
    public  class GetPersonResponse
    {
        public string Name { get; set; }

        public bool CanHaveCat { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
