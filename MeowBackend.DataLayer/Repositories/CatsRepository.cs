namespace MeowBackend.DataLayer.Repositories;
using MeowBackend.Core.Dtos;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

public class CatsRepository: BaseRepository, ICatsRepository
{

    private readonly ILogger _logger = Log.ForContext<CatsRepository>(); //инстанс логгера

    public CatsRepository(MeowDBContext context) : base(context)
    {
    }

    public List<CatDto> GetCats()
    {
        return _ctx.Cats.Include(c => c.Owner).ToList();
    }


    public CatDto GetCatById(Guid id)
    {
        _logger.Information($"идем в базу данных искать кота с id {id}");
        return _ctx.Cats.Include(c => c.Owner).FirstOrDefault(d => d.Id == id);
    }
    public List<CatDto> GetCatsByPersonId(Guid personId) => _ctx.Cats.Include(c=>c.Owner).Where(d => d.Owner.Id == personId).ToList();

    

    public Guid CreateCat(CatDto cat)
    {
        cat.CatType = Core.Enums.CatType.Meow1;
        _ctx.Cats.Add(cat);
        _ctx.SaveChanges();

        _logger.Information($"Успешно. Возвращаем Id КОТА по имени {cat.CatName}");
        return cat.Id;
    }

}
