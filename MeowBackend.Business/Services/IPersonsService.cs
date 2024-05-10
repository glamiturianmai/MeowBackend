using MeowBackend.Core.Dtos;
using MeowBackend.Core.Models.Requestes;
using MeowBackend.Core.Models.Responses;

namespace MeowBackend.Business.Services
{
    public interface IPersonsService
    {
        public List<PersonResponse> GetPersons();

        public PersonResponse GetPersonById(Guid id);

        public List<CatResponse> GetCatsByPersonId(Guid id);

        public Guid CreatePerson(CreatePersonRequest request);
        public Guid UpdatePersonAuthorization(Guid id, UpdateAuthorizationPersonRequest request);
    }
}