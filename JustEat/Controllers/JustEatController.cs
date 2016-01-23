using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using JustEat.Models;
using JustEat.Queries;
using JustEat.Services;

namespace JustEat.Controllers
{
    public class JustEatController : ApiController
    {
        private readonly IRestaurantByPostcodeService _restaurantByPostcodeService;

        public JustEatController()
        {
            _restaurantByPostcodeService = new RestaurantByPostcodeService(new RestaurantByPostcodeQuery() );
        }

        public async Task<IEnumerable<RestaurantViewModel>> Get(string postcode)
        {
            return await _restaurantByPostcodeService.GetAsync(postcode);
        }
    }
}