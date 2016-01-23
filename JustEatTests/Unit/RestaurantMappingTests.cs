using JustEat.Models;
using Ploeh.AutoFixture;
using Should;
using Xunit;

namespace JustEatTests.Unit
{
    public class RestaurantMappingTests
    {
        [Fact]
        public void ShouldMapRestaurantToRestaurantViewModel()
        {
            // Arrange
            var fixture = new Fixture();
            var restaurant = fixture.Create<Restaurant>();
            var cuisineStrings = new string[restaurant.CuisineTypes.Count];

            for (var i = 0; i < restaurant.CuisineTypes.Count; i++)
            {
                cuisineStrings[i] = restaurant.CuisineTypes[i].Name;
            }

            var delimitedCuisine = string.Join(", ", cuisineStrings);

            // Act
            var restaurantViewModel = restaurant.ToRestaurantViewModel();

            // Assert
            restaurantViewModel.Cuisine.ShouldEqual(delimitedCuisine);
            restaurantViewModel.Name.ShouldEqual(restaurant.Name);
            restaurantViewModel.Rating.ShouldEqual(restaurant.RatingStars);
        }
    }
}
