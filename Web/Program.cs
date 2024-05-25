using Web.Components;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

var weatherApiBaseAddress = builder.Configuration.GetValue<string>("WeatherApiBaseAddress");
if (string.IsNullOrEmpty(weatherApiBaseAddress))
{
    throw new Exception("Missing WeatherApiBaseAddress in appsettings.json");
}

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("weather", client => client.BaseAddress = new Uri(weatherApiBaseAddress));
builder.Services.AddScoped<WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
