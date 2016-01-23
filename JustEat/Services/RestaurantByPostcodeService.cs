using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustEat.Models;
using JustEat.Queries;

namespace JustEat.Services
{
    public class RestaurantByPostcodeService : IRestaurantByPostcodeService
    {
        private readonly IRestaurantByPostcodeQuery _restaurantByPostCodeQuery;

        public RestaurantByPostcodeService(IRestaurantByPostcodeQuery restaurantByPostCodeQuery)
        {
            _restaurantByPostCodeQuery = restaurantByPostCodeQuery;
        }

        public async Task<IEnumerable<RestaurantViewModel>> GetAsync(string postcode)
        {
            var results = await _restaurantByPostCodeQuery.GetAsync(postcode);

            return results.Restaurants.Select(x => RestaurantMappingExtension.ToRestaurantViewModel(x));
        }
    }
}