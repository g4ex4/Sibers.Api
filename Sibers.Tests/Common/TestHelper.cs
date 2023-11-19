using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Sibers.Tests.Common
{
    public static class TestHelper<T>
    {
        private static string _apiBaseUri = "https://localhost:7105";

        public static T MakeRequest(HttpClient client, string httpMethod, string route, object bodyParameters = null,
            object queryParameters = null)
        {
            string queryString = queryParameters != null
            ? $"?{string.Join("&", ToQueryString(queryParameters).Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value.ToString())}"))}"
            : string.Empty;

            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), $"{_apiBaseUri}/{route}{queryString}");

            if (bodyParameters != null)
            {
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(bodyParameters));
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }


            HttpResponseMessage response = client.SendAsync(requestMessage).Result;

            string apiResponse = response.Content.ReadAsStringAsync().Result;
            try
            {
                if (apiResponse != "")
                    return JsonConvert.DeserializeObject<T>(apiResponse);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error ocurred while calling the API. It responded with the following message: {response.StatusCode} {response.ReasonPhrase}");
            }
        }

        private static Dictionary<string, object> ToQueryString(object parameters)
        {
            var properties = parameters.GetType().GetProperties()
                .Where(x => x.GetValue(parameters) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(parameters));

            return properties;
        }
    }

    public class ModifyByIdDto
    {
        public long Id { get; set; }
    }

    public class ModifyByNameDto
    {
        public string Name { get; set; }
    }
}
