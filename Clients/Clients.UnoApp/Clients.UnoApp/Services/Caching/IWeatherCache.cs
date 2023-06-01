using Clients.UnoApp.DataContracts;
using System.Collections.Immutable;

namespace Clients.UnoApp.Services.Caching
{
    public interface IWeatherCache
    {
        ValueTask<IImmutableList<WeatherForecast>> GetForecast(CancellationToken token);
    }
}