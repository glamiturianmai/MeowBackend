using MeowBackend.Core.Dtos;
using MeowBackend.Core.Enums;

namespace MeowBackend.Core.Models.Requestes;

public class CreateCatRequest
{
    public string CatName { get; set; }

    public CatType CatType { get; set; }

    public bool CanMeow { get; set; }

}
