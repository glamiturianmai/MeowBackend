namespace MeowBackend.Core.Models.Requestes;

public  class CreatePersonRequest
{
    public string Name { get; set; }

    public bool CanHaveCat { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }
    
}
