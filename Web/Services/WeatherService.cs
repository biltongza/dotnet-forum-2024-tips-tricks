using System.Net.Http;
using Lib.Models;
namespace Web.Services;

public class WeatherService : IDisposable
{
    private readonly HttpClient httpClient;

    public WeatherService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient("weather");
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
    {
        return await httpClient.GetFromJsonAsync<List<WeatherForecast>>("/weatherforecast");
    }

    public void Dispose()
    {
        httpClient?.Dispose();
    }
}
