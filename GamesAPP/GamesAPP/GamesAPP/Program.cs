using GamesAPP.Client.Pages;
using GamesAPP.Components;
using GamesAPP.Shared.Data;
using GamesAPP.Shared.Services;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using GamesAPP.Shared.Entities;
using GamesAPP;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
	.AddInteractiveServerComponents();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2",
        new OpenApiSecurityScheme()
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        }
    );

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
//builder.Services.AddAuthorization();
//builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<DataContext>();

DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
builder.Services.AddDbContext<DataContext>(
    options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DabaseConnection"),
		b => b.MigrationsAssembly("GamesAPP")
    )
);
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped(http => new HttpClient
{
	BaseAddress = new Uri(builder.Configuration.GetSection("HttpClientURI").Value!)
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(swagger =>
	{
		swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Games APP SWAGGER API");
	});

	if (builder.Configuration.GetValue<bool>("SeedDatabase"))
	{
        try
		{
			using (var scope = app.Services.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
				var gameSeeder = new DataSeeder(dbContext);
				gameSeeder.SeedData<Product, Product>(20);
				gameSeeder.SeedData<Warehouse, Warehouse>(10);
				gameSeeder.SeedData<User, User>(5);
				gameSeeder.SeedData<Order, Order>(100);
				gameSeeder.SeedData<Post, Post>(50);
			}

			Console.WriteLine("Database generate correctly\n\n");
		}
        catch 
        {
			Console.WriteLine("Error during database generation\n\n");
		}
	}
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.MapIdentityApi<IdentityUser>();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthorization();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
.AddInteractiveWebAssemblyRenderMode();

app.Run();