using MeowBackend.Core.Dtos;
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


    //private static bool ComparePassword(DogDto dog)
    //{
    //    var passwordHash = HashPassword.ComputeHash(dog.Password, dog.PasswordSalt, _pepper, _iteration);
    //    if (dog.PasswordHash != passwordHash)
    //    {
    //        Log.Debug($"Пароль пользователя не совпадает: {dog.Name}");
    //        //throw new AuthenticationException("Username or password did not match.");
    //    }

    //    return true;
    //}


    public Guid CreateUser(DogDto dto)
    {

        // user.Id = Guid.NewGuid();
        dto.PasswordSalt = HashPassword.GenerateSalt();
       // dto.PasswordHash = HashPassword.ComputeHash(request.Password, dto.PasswordSalt, _pepper, _iteration);

        return _dogsRepository.CreateDog(dto);
        
    }




    public Guid CreateDog(DogDto dto)
    {
        return _dogsRepository.CreateDog(dto);

    }
}