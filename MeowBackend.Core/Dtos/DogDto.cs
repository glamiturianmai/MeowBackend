using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowBackend.Core.Dtos
{
    public class DogDto: IdContainer
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}

