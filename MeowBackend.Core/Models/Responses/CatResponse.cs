using MeowBackend.Core.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeowBackend.Core.Models.Responses;

public class CatResponse
{
    public Guid Id { get; set; }
    public string CatName { get; set; } 

    public int Count { get; set; }

    public CatType CatType { get; set; }

    public bool CanMeow { get; set; }

    public PersonResponse Owner { get; set; }

}
