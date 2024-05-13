using MeowBackend.Core.Dtos;

namespace MeowBackend.Business.Services
{
    public interface IDogsService
    {
        public Guid AddDog(DogDto dto);
        DogDto GetDogById(Guid id);

        public void DeleteDog(Guid id);

        public List<DogDto> GetDogs();
    }
}