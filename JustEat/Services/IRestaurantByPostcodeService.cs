using System.Collections.Generic;
using System.Threading.Tasks;
using JustEat.Models;

namespace JustEat.Services
{
    public interface IRestaurantByPostcodeService
    {
        Task<IEnumerable<RestaurantViewModel>> GetAsync(string postcode);
    }
}