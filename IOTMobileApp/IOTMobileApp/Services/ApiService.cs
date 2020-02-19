using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IOTMobileApp.Services
{
    public class ApiService
    {
        public static async  Task<bool> Authorised(string email, string password)
        {
            var url = "https://homekit.local/api/auth/token";
            var parameters = new Dictionary<string, string> { { "username", email }, { "password", password } };
            var encodedContent = new FormUrlEncodedContent(parameters);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(url, encodedContent).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                    // Do something with response. Example get content:
                    // var responseContent = await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
                }
            }

           

            //var url = VenueRoot.GenerateURL(latitude, longitude)
            //"https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";
            //var url = "https://localhost:44304/weatherforecast";

            //using (HttpClient client = new HttpClient())
            //{
            //    var response = await client.GetAsync(url);
            //    var json = await response.Content.ReadAsStringAsync();

            //    var venueRoot = JsonConvert.DeserializeObject<bool>(json);

            //    //venues = venueRoot.response.venues as List<Venue>;
            //}
            return false;
        }
    }
}
