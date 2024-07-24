using Blazored.LocalStorage;
using SlottyMedia.Backend.Models;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Components;
using Supabase;
using ILocalStorageService = SlottyMedia.Backend.Services.Interfaces.ILocalStorageService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Blazored LocalStorage
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ILocalStorageService>(p =>
    new LocalStorageService(p.GetRequiredService<Blazored.LocalStorage.ILocalStorageService>()));
// Add Supabase
builder.Services.AddScoped(_ =>
    new Client(
        builder.Configuration["SupabaseSettings:Url"],
        builder.Configuration["SupabaseSettings:Key"],
        new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        }));

// Viewmodel
builder.Services.AddScoped<ICounterVm, CounterVm>();
builder.Services.AddScoped<IAuthVm, AuthVM>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Model
builder.Services.AddScoped<UserDto>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();