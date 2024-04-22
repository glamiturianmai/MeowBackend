using MeowBackend.Core.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MeowBackend.DataLayer.Repositories;

public class PersonsRepository : BaseRepository, IPersonsRepository
{
    public PersonsRepository(MeowDBContext context) : base(context)
    {

    }

    public PersonDto GetPersonById(Guid id) => _ctx.Persons.FirstOrDefault(d => d.Id == id);



}
