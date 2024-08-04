using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Components;
using SlottyMedia.Database.Models;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Supabase
builder.Services.AddSingleton(_ =>
    new Client(
        builder.Configuration["SupabaseSettings:Url"],
        builder.Configuration["SupabaseSettings:Key"],
        new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        }));

//Register
builder.Services.AddHttpClient();

// Viewmodel
builder.Services.AddSingleton<ICounterVm, CounterVm>();


// Services
builder.Services.AddSingleton<IUserService, UserService>();


builder.Services.AddScoped<IAuthService, AuthService>();  // Scoped
builder.Services.AddScoped<IAuthVm, AuthVm>(); 

// Model
builder.Services.AddSingleton<UserDto>();

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