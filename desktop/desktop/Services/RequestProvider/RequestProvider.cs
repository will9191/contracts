using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using desktop.Services.Settings;


namespace desktop.Services.RequestProvider
{
    public class RequestProvider (ISettingsService settingsService) : IRequestProvider
    {
        private readonly ISettingsService _settingsService = settingsService;
        private readonly Lazy<HttpClient> _httpClient =
            new(() =>
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new System
                    .Net
                    .Http
                    .Headers
                    .MediaTypeWithQualityHeaderValue("application/json"));
                return httpClient;
            });

        public async Task<TResult> PostAsync<TResult, TSend>(string uri, TSend data)
        {
            var httpClient = GetOrCreateHttpClient();

            HttpContent body;
            if (data is HttpContent httpContent)
            {
                body = httpContent;
            }
            else
            {
                body = new StringContent(JsonSerializer.Serialize(data));
                body.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            var response = await httpClient.PostAsync(uri, body).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Requisição falhou: {response.StatusCode} - {errorContent}");
            }

            return await response.Content.ReadFromJsonAsync<TResult>();
        }

        public async Task<TResult> GetAsync<TResult, TSend>(string uri, TSend queryParams)
        {
            var httpClient = GetOrCreateHttpClient();

            var query = ToQueryString(queryParams);
            var fullUri = string.IsNullOrWhiteSpace(query) ? uri : $"{uri}?{query}";

            System.Diagnostics.Debug.WriteLine(fullUri);

            var response = await httpClient.GetAsync(fullUri).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)

                throw new Exception("Requisição falhou");

            return await response.Content.ReadFromJsonAsync<TResult>();
        }

        private HttpClient GetOrCreateHttpClient()
        {
            var token = _settingsService.AccessToken;
            var httpClient = _httpClient.Value;
            httpClient.DefaultRequestHeaders.Clear();

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");
            }

            return httpClient;
        }

        private static string ToQueryString<T>(T obj)
        {
            if (obj == null) return "";

            var properties = typeof(T).GetProperties()
       .Where(p => p.GetValue(obj) != null)
       .Select(p =>
       {
           var jsonAttr = p.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false)
                           .Cast<JsonPropertyNameAttribute>()
                           .FirstOrDefault();

           var name = jsonAttr != null ? jsonAttr.Name : p.Name;
           var value = p.GetValue(obj)?.ToString() ?? "";

           return $"{Uri.EscapeDataString(name)}={Uri.EscapeDataString(value)}";
       });

            return string.Join("&", properties);
        }
    }
}
