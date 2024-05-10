namespace MeowBackend.Core.Models.Responses;

public class PersonResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool CanHaveCat { get; set; }

    public string Email { get; set; }
}
