using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JustEat.Models;

namespace JustEat.Queries
{
    public class RestaurantByPostcodeQuery : IRestaurantByPostcodeQuery
    {
        public async Task<RootObject> GetAsync(string postcode)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api-interview.just-eat.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
                client.DefaultRequestHeaders.Add("Accept-Language", "en-GB");
                client.DefaultRequestHeaders.Add("Host", "api-interview.just-eat.com");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    "VGVjaFRlc3RBUEk6dXNlcjI=");

                var response = await client.GetAsync(string.Format("restaurants?q={0}", postcode));

                if (!response.IsSuccessStatusCode) return null;
                return await response.Content.ReadAsAsync<RootObject>();
            }
        }
    }
}