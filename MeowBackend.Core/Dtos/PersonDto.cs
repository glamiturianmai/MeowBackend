namespace MeowBackend.Core.Dtos
{
    public class PersonDto : IdContainer
    {
        public string Name { get; set; }

        public bool CanHaveCat { get; set; }

        public List<CatDto> Cats { get; set; }
    }
}
