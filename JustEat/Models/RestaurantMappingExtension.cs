using System;

namespace JustEat.Models
{
    public static class RestaurantMappingExtension
    {
        public static RestaurantViewModel ToRestaurantViewModel(this Restaurant restaurant)
        {
            return new RestaurantViewModel
            {
                Name = restaurant.Name,
                Rating = restaurant.RatingStars,
                Cuisine = string.Join(", ", Array.ConvertAll(restaurant.CuisineTypes.ToArray(), x => x.Name))
            };
        }
    }
}