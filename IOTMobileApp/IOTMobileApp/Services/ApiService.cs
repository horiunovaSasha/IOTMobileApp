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

            //var url = VenueRoot.GenerateURL(latitude, longitude)
            //"https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";
            var url = "http://localhost:5001/api/auth/test";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();

                    var venueRoot = JsonConvert.DeserializeObject<bool>(json);
                } catch (Exception ex)
                {
                    
                }
                //venues = venueRoot.response.venues as List<Venue>;
            }
            return false;
        }

        private static HttpClient GetHttpClient()
        {
            return new HttpClient
            (
                new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                }
            , false
            );
        }
    }
}
