using MeowBackend.Core.Dtos;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;

namespace MeowBackend.DataLayer.Repositories;

public class DogsRepository : BaseRepository, IDogsRepository
{


    private readonly ILogger _logger = Log.ForContext<DogsRepository>();
    public DogsRepository(MeowDBContext context) : base(context)
    {

    }
    
    public List<DogDto> GetDogs() => _ctx.Dogs.ToList();
    public DogDto GetDogById(Guid id) => _ctx.Dogs.FirstOrDefault(d => d.Id == id);

    public Guid AddDog(DogDto dog)
    {
        _logger.Debug($"собака в репозитории с именем {dog.Name}");


        _ctx.Dogs.Add(dog);
        _ctx.SaveChanges();

        _logger.Debug($"Успешно. Возвращаем Id собаки по имени {dog.Name}");

        return dog.Id;
    }

    public void DeleteDog(Guid id)
    {
        DogDto dog = _ctx.Dogs.FirstOrDefault(d => d.Id == id);
        _logger.Debug($"DogsRepository -DeleteAddDog {dog.Name}");
        dog.IsDeleted = true;
        _ctx.Dogs.Update(dog);
        _ctx.SaveChanges();

        _logger.Debug($"Успешно.");

    }

}
