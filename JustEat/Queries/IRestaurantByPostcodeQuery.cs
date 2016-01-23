using System.Threading.Tasks;
using JustEat.Models;

namespace JustEat.Queries
{
    public interface IRestaurantByPostcodeQuery
    {
        Task<RootObject> GetAsync(string postcode);
    }
}