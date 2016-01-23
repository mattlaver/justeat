using System.Linq;
using System.Threading.Tasks;
using JustEat.Models;
using JustEat.Queries;
using JustEat.Services;
using NSubstitute;
using Ploeh.AutoFixture;
using Should;
using Xunit;

namespace JustEatTests.Unit
{
    public class RestaurantByPostcodeServiceTests
    {
        [Fact]
        public void ShouldReturnRestaurantViewModels()
        {
            // Arrange
            var fixture = new Fixture();
            var rootObject = fixture.Create<RootObject>();
            var restaurantByPostcodeQuery =  Substitute.For<IRestaurantByPostcodeQuery>();
            restaurantByPostcodeQuery.GetAsync(Arg.Any<string>()).Returns(Task.FromResult(rootObject));
            var restaurantByPostcodeService = new RestaurantByPostcodeService(restaurantByPostcodeQuery);

            // Act
            var results = restaurantByPostcodeService.GetAsync("SW1");

            // Assert

            results.ShouldNotBeNull();
            results.Result.ShouldNotBeNull();
            results.Result.Count().ShouldEqual(rootObject.Restaurants.Count);
        }
    }
}
