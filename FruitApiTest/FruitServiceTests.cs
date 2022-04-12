using FruitApi.Services;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using System;
using Moq;
using System.Net.Http;
using FruitApi.Configuration;
using FruitApi.DTO.Endpoints;

namespace FruitApiTest
{
    public class Tests
    {
        private UrlSettings fruitUrls;

        private readonly FruitModel fruit;
        private readonly CategorisationModel categorisation;
        private readonly NutritionModel nutrition;

        private Mock<IHttpClientFactory> mockHttpClientFactory;

        public Tests()
        {
            fruitUrls = new UrlSettings()
            {
                FruitInfoUrl = "https://fruitinfo.azurewebsites.net/api/Info",
                FruitNutritionsUrl = "http://fruitnutritions.azurewebsites.net/api/nutritions"
            };

            mockHttpClientFactory = new Mock<IHttpClientFactory>();

            fruit = new FruitModel()
            {
                Name = "Apple",
            };

            categorisation = new CategorisationModel()
            {
                Genus = "Malus",
                Family = "Rosaceae",
            };

            nutrition = new NutritionModel()
            {
                Name = "Apple",
                Per = "100g",
                Cals = "52",
                Protein = "0.3",
                Fat = "0.4",
                Sugar = "10.3",
                Carbs = "11.4"
            };
        }

        [Theory]
        [InlineData("apple")]
        [InlineData("pear")]
        public async Task SuccessfullyGetFruit(string fruit)
        {
            // Arrange
            var sut = new FruitService(mockHttpClientFactory.Object);

            // Act
            var result = await sut.GetFruitAsync(fruit, fruitUrls);

            // Assert
            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData("apples")]
        [InlineData("pears")]
        public async Task FailToGetFruit(string fruit)
        {
            // Arrange
            var sut = new FruitService(mockHttpClientFactory.Object);

            // Assert
            await Should.ThrowAsync<Exception>(async () =>
            {
                _ = await sut.GetFruitAsync(fruit, fruitUrls);
            });
        }
    }
}