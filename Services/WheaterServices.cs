using System;
using RestSharp;

namespace weather_forecast_bot
{
    public class WheaterServices
    {
        // Default Chishinau 
        public static WheaterModel GetWheater(double lat = 47.024512, double lon = 28.832157, bool extra = false, string lang = "en_US", bool hours = false, int limit = 3)
        {
            var client = new RestClient($"https://api.weather.yandex.ru/v2/forecast");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-yandex-api-key", "08726e4d-ed41-4b98-ac81-0fe7f022114d");
            request.AddParameter("lat", lat);
            request.AddParameter("lat", lat);
            request.AddParameter("lon", lon);
            request.AddParameter("lang", lang);
            request.AddParameter("limit", limit);
            request.AddParameter("extra", extra);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                // Console.WriteLine(response.Content);
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<WheaterModel>(response.Content);
                return obj;
            }
            throw new Exception($"{response.StatusCode} {response.StatusDescription}");
        }
    }
}