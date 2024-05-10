using AutoMapper;
using MeowBackend.Core.Dtos;

namespace MeowBackend.Core.Models.Requestes;

public class MappingRequestProfile: Profile
{
    public MappingRequestProfile()
    {
        CreateMap<CreateCatRequest, CatDto>();
        CreateMap<CreatePersonRequest, PersonDto>();
    }
}
