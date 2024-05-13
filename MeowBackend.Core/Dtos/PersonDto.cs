namespace MeowBackend.Core.Dtos
{
    public class PersonDto : IdContainer
    {
        public string Name { get; set; }

        public bool CanHaveCat { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public List<CatDto> Cats { get; set; }

        public bool IsDeleted { get; set; }
    }
}
