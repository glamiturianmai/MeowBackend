using AutoMapper;
using MeowBackend.Core.Dtos;

namespace MeowBackend.Core.Models.Responses;

public class MappingResponseProfile : Profile
{
    public MappingResponseProfile()
    {
        CreateMap<PersonDto, GetPersonResponse>();
        CreateMap<PersonDto, PersonResponse>();
        CreateMap<CatDto, CatResponse>();
    }
}

