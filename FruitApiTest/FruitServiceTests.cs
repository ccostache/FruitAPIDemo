using FruitApi.Services;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using System;

namespace FruitApiTest
{
    public class Tests
    {
        [Theory]
        [InlineData("apple")]
        [InlineData("pear")]
        public async Task SuccessfullyGetFruit(string fruit)
        {
            var sut = new FruitService();

            var result = await sut.GetFruitAsync("apple");

            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData("apples")]
        [InlineData("pears")]
        public async Task FailToGetFruit(string fruit)
        {
            var sut = new FruitService();

            await Should.ThrowAsync<Exception>(async () =>
            {
                _ = await sut.GetFruitAsync(fruit);
            });
        }
    }
}