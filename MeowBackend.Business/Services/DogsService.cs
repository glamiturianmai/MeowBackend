using MeowBackend.Core.Dtos;
using MeowBackend.Core.Exceptions;
using MeowBackend.DataLayer.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Serilog;

namespace MeowBackend.Business.Services;

public class DogsService : IDogsService
{
    private readonly IDogsRepository _dogsRepository;
    private readonly ILogger _logger = Log.ForContext<CatsService>();

    private const string _pepper = "dog";
    private const int _iteration = 3;


    public DogsService(IDogsRepository dogsRepository)
    {
        _dogsRepository = dogsRepository;
    }
    public DogDto GetDogById(Guid id) => _dogsRepository.GetDogById(id);

    public List<DogDto> GetDogs() => _dogsRepository.GetDogs();




    public Guid AddDog(DogDto dto)
    {
        if (dto.Count  < 0 || dto.Count>100) 
        {
            throw new ValidationException("укажите возраст корректно");
        }
        if (dto.Name.Length < 3 || dto.Name.Length > 10)
        {
            throw new ValidationException("укажите имя корректно");
        }
        return _dogsRepository.AddDog(dto);
        
    }

    public void DeleteDog(Guid id)
    {
        _logger.Debug($"DogsService - DeleteAddDog {_dogsRepository.GetDogById(id).Name}");
        _dogsRepository.DeleteDog(id);
    }

}