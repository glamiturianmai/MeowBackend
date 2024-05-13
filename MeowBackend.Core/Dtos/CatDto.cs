using MeowBackend.Core.Enums;
namespace MeowBackend.Core.Dtos;

public class CatDto : IdContainer
{
    public string CatName { get; set; }

    public CatType CatType { get; set; }

    public bool CanMeow { get; set; }

    public PersonDto Owner { get; set; }

    public bool IsDeleted { get; set; }

}
