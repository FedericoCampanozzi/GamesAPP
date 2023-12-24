using GamesAPP.Client.Pages;
using GamesAPP.Components;
using GamesAPP.Shared.Data;
using GamesAPP.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
	.AddInteractiveServerComponents();

builder.Services.AddControllers();

DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
builder.Services.AddDbContext<DataContext>(
    options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DabaseConnection"),
		b => b.MigrationsAssembly("GamesAPP")
    )
);
builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddScoped(http => new HttpClient
{
	BaseAddress = new Uri(builder.Configuration.GetSection("HttpClientURI").Value!)
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();