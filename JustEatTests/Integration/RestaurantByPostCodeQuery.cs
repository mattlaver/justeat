using JustEat.Queries;
using Should;
using Xunit;

namespace JustEatTests.Integration
{
    public class RestaurantByPostCodeQueryTests
    {
        [Fact]
        public void ShouldReturnDataFromJustEatApi()
        {
            // Arrange
            var query = new RestaurantByPostcodeQuery();
            
            // Act
            var results = query.GetAsync("HP4 1PA");

            // Assert 
            results.ShouldNotBeNull();
            results.Result.Restaurants.ShouldNotBeNull();
            results.Result.Restaurants.Count.ShouldBeGreaterThan(0);
        }      
    }
}
