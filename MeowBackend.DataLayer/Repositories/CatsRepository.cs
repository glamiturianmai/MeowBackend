namespace MeowBackend.DataLayer.Repositories;
using MeowBackend.Core.Dtos;


public class CatsRepository: BaseRepository, ICatsRepository
{
    public CatsRepository(MeowDBContext context) : base(context)
    {
    }

    public List<CatDto> GetCats()
    {
        return _ctx.Cats.ToList();
    }

    //public CatDto GetCatById(Guid id)
    //{
    //    // уже сходили в базу, лол
    //    return new()
    //    {
    //        CanMeow = true,
    //        Id = id,
    //        CatName = "Funtik",
    //        Count=65
    //    };
    //}

    public CatDto GetCatById(Guid id) => _ctx.Cats.FirstOrDefault(d => d.Id == id);
    public CatDto GetCatByPersonId(Guid personId) => _ctx.Cats.FirstOrDefault(d => d.Owner.Id == personId);
}
