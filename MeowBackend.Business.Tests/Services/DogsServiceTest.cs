using AutoMapper;
using FluentValidation;
using MeowBackend.Business.Services;
using MeowBackend.Core.Dtos;
using MeowBackend.Core.Models.Requestes;
using MeowBackend.DataLayer.Repositories;
using Moq;
using MeowBackend.Core.Exceptions;
using ValidationException = MeowBackend.Core.Exceptions.ValidationException;
using NotFoundException = MeowBackend.Core.Exceptions.NotFoundException;


namespace MeowBackend.Business.Tests.Services
{
    public class DogsServiceTest
    {
        private const string _guidPattern = "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
        private readonly Mock<IDogsRepository> _dogRepositoryMock;
        


        public DogsServiceTest()
        {
            _dogRepositoryMock = new Mock<IDogsRepository>();
            
        }

        [Theory]
        [InlineData("Test")]
        //позитивный тест
        public void CreateDog_ValidDtoSent_GuidReceived(string name) //метод/что воспроизводим/что получаем
        {
            //arrange
            var validDogDto = new DogDto()
            {
                Name = name,
                Count=10

            };
           
            var expectedGuid = Guid.NewGuid();
            _dogRepositoryMock.Setup(x => x.AddDog(It.IsAny<DogDto>())).Returns(expectedGuid);
            var sut = new DogsService(_dogRepositoryMock.Object);

            //act
            var actual = sut.AddDog(validDogDto);

            //assert
            Assert.Matches(_guidPattern, actual.ToString());
            Assert.NotEqual("00000000-0000-0000-0000-000000000000", actual.ToString());
        }


        [Theory]
        [InlineData("Test")]
        [InlineData("qqqqqq")]
        [InlineData("qqqq")]
        //негативный тест
        public void CreateDog_DtoWithInvalidCountSent_CountErrorReceived(string name) //метод/что воспроизводим/что получаем
        {
            //arrange
            var invalidDogDto = new DogDto()
            {
                Name = name,
                Count = 101

            };

            var expectedGuid = Guid.NewGuid();
            _dogRepositoryMock.Setup(x => x.AddDog(It.IsAny<DogDto>())).Returns(expectedGuid);
            var sut = new DogsService(_dogRepositoryMock.Object);

            //act, assert
            Assert.Throws<ValidationException>(() => sut.AddDog(invalidDogDto));

        }

        [Fact]
        //негативный тест
        public void CreateDog_DtoWithInvalidNameSent_NameErrorReceived() //метод/что воспроизводим/что получаем
        {
            //arrange
            var invalidDogDto = new DogDto()
            {
                Name = "",
                Count = 10

            };

            var expectedGuid = Guid.NewGuid();
            _dogRepositoryMock.Setup(x => x.AddDog(It.IsAny<DogDto>())).Returns(expectedGuid);
            var sut = new DogsService(_dogRepositoryMock.Object);

            //act, assert
            Assert.Throws<ValidationException>(() => sut.AddDog(invalidDogDto));

        }

        //deletedog 

        [Fact]
        //позитивный тест
        public void GetDogs_Called_DogsReceived() //метод/что воспроизводим/что получаем
        {
            //arrange
            var dto1 = new DogDto() { Name = "dog1" };
            var dto2 = new DogDto() { Name = "dog2" };
            
            var expected1 = new List<DogDto>() { dto1, dto2 };
            var expected2 = new List<DogDto>() { dto1, dto2 };

            _dogRepositoryMock.Setup(x => x.GetDogs()).Returns(expected2);
            var sut = new DogsService(_dogRepositoryMock.Object);

            //act
            var actual = sut.GetDogs();
            
            //assert
            Assert.Equal(expected1, actual);
            _dogRepositoryMock.Verify(x => x.GetDogs(), Times.Once);

        }

        [Fact]
        //позитивный тест
        public void DeleteDogById_ValidGuidSent_NotErrorReceived() //метод/что воспроизводим/что получаем
        {
            //arrange         
            var dogId =Guid.NewGuid();
            _dogRepositoryMock.Setup(x => x.GetDogById(dogId)).Returns(new DogDto());
            var sut = new DogsService(_dogRepositoryMock.Object);

            //act
            sut.DeleteDog(dogId);

            //assert
            _dogRepositoryMock.Verify(x => x.GetDogById(dogId), Times.Once);
            _dogRepositoryMock.Verify(x => x.DeleteDog(dogId), Times.Once);

        }


        [Fact]
        //негативный тест //НЕ РАБОТАЕТ
        public void DeleteDogById_EmptydGuidSent_NotErrorReceived() //метод/что воспроизводим/что получаем
        {
            //arrange         
            var dogId = Guid.Empty;
            _dogRepositoryMock.Setup(x => x.GetDogById(dogId)).Returns((DogDto)null);
            var sut = new DogsService(_dogRepositoryMock.Object);

            //act, assert
            Assert.Throws<NotFoundException>(()=>sut.DeleteDog(dogId));

            //assert
            _dogRepositoryMock.Verify(x => x.GetDogById(dogId), Times.Once);
            _dogRepositoryMock.Verify(x => x.DeleteDog(dogId), Times.Never);

        }
    }
}
