using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using BlazorApp7.Client;
using BlazorApp7.Client.Shared;
using BlazorApp7.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp7.Client.Pages
{
    public partial class FetchData : OwningComponentBase
    {
        private WeatherForecast[]? forecasts;

        private HttpClient? _httpClient;

        protected override void OnInitialized()
        {
            _httpClient = ScopedServices.GetRequiredService<HttpClient>();
        }

        protected override async Task OnInitializedAsync()
        {

            forecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}
