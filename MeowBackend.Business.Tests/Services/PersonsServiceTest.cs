using AutoMapper;
using FluentValidation;
using MeowBackend.Business.Services;
using MeowBackend.Core.Dtos;
using MeowBackend.Core.Models.Requestes;
using MeowBackend.DataLayer.Repositories;
using Moq;
using Serilog;

namespace MeowBackend.Business.Tests.Services
{
    public class PersonsServiceTest
    {
        private const string _guidPattern = "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
        private readonly Mock<IPersonsRepository> _personRepositoryMock;
        private readonly IMapper _mapper;
        private readonly ILogger _logger = Log.ForContext<CatsService>();

        private const string _pepper = "person";
        private const int _iteration = 3;

        private readonly IValidator<CreatePersonRequest> _personValidator;
        private readonly IValidator<UpdateAuthorizationPersonRequest> _personAuthorizationValidator;


        public PersonsServiceTest(IMapper mapper, IValidator<CreatePersonRequest> personValidator, IValidator<UpdateAuthorizationPersonRequest> personAuthorizationValidator)
        {
            _personRepositoryMock = new Mock<IPersonsRepository>();
            _mapper = mapper;
            _personValidator = personValidator;
            _personAuthorizationValidator = personAuthorizationValidator;
        }

        [Fact]
        //позитивный тест
        public void CreatePerson_ValidRequestSent_GuidReceived() //метод/что воспроизводим/что получаем
        {
            //arrange
            var validPersonRequest = new CreatePersonRequest()
            {
                Name = "Test",
                CanHaveCat = true,
                Email = "qqqqq@qqq.qq",
            };
            var dto = _mapper.Map<PersonDto>(validPersonRequest);
            var expectedGuid = Guid.NewGuid();
            _personRepositoryMock.Setup(x => x.CreatePerson(It.IsAny<PersonDto>())).Returns(expectedGuid);
            var sut = new PersonsService(_personRepositoryMock.Object, _mapper, _personValidator, _personAuthorizationValidator);

            //act
            var actual = sut.CreatePerson(validPersonRequest);

            //assert
            Assert.Matches(_guidPattern, actual.ToString());
            Assert.NotEqual("00000000-0000-0000-0000-000000000000", actual.ToString());
        }
    }
}
