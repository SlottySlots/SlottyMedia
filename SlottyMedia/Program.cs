using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Components;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.DatabaseSeeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Supabase
builder.Services.AddSingleton(_ =>
    InitializeSupabaseClient.GetSupabaseClient());


// Database
builder.Services.AddSingleton<IDatabaseActions, DatabaseActions>();

// Daos
builder.Services.AddSingleton<UserDao>();
builder.Services.AddSingleton<PostsDao>();
builder.Services.AddSingleton<ForumDao>();
builder.Services.AddSingleton<CommentDao>();
builder.Services.AddSingleton<FollowerUserRelationDao>();
builder.Services.AddSingleton<UserLikePostRelationDao>();

// DtOs
builder.Services.AddSingleton<UserDto>();
builder.Services.AddSingleton<PostDto>();
builder.Services.AddSingleton<ForumDto>();
builder.Services.AddSingleton<FriendsOfUserDto>();
builder.Services.AddSingleton<ProfilePicDto>();
builder.Services.AddSingleton<SearchDto>();


// Viewmodel
builder.Services.AddScoped<ISignupFormVm, SignupFormVmImpl>();


// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICookieService, CookieService>();
builder.Services.AddScoped<IAuthService, AuthService>(); // Scoped
builder.Services.AddScoped<ISignupService, SignupServiceImpl>();
builder.Services.AddScoped<ISearchService, SearchService>();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IDatabaseActions>();
    Seeding seeding = new(seeder);
    await seeding.Seed(seeder);
}

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