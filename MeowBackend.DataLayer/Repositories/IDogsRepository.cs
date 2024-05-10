using MeowBackend.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowBackend.DataLayer.Repositories
{
    public interface IDogsRepository
    {
        public DogDto GetDogById(Guid id);
        public Guid CreateDog(DogDto dog);

    }
}
