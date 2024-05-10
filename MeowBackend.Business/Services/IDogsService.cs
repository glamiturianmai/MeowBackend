using MeowBackend.Core.Dtos;

namespace MeowBackend.Business.Services
{
    public interface IDogsService
    {
        Guid CreateDog(DogDto dto);
        DogDto GetDogById(Guid id);
    }
}