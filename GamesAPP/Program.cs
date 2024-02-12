using GamesAPP;
using GamesAPP.Components;
using GamesAPP.Data;
using GamesAPP.Entities;
using GamesAPP.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Swashbuckle.AspNetCore.Filters;

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

DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
builder.Services.AddDbContext<DataContext>(
    options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DabaseConnection"),
		b => b.MigrationsAssembly("GamesAPP")
    )
);
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();

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

				Order.DeleteAllItems(dbContext);
				Post.DeleteAllItems(dbContext);
				User.DeleteAllItems(dbContext);
				Warehouse.DeleteAllItems(dbContext);
				Product.DeleteAllItems(dbContext);

				var gameSeeder = new DataSeeder(dbContext);
				gameSeeder.SeedData<Product, Product>(20);
				gameSeeder.SeedData<Warehouse, Warehouse>(10);
				gameSeeder.SeedData<User, User>(5);
				// Need to be chuncked because some order made from user and some from store
				int chunck = 20;
				int nForChunck = 5;
				for (int i = 0; i < chunck; i++)
					gameSeeder.SeedData<Order, Order>(nForChunck);
				// ***
				gameSeeder.SeedData<Post, Post>(50);
			}

			Console.WriteLine("Database generate correctly\n\n");
		}
		catch(Exception e)
		{
			Console.WriteLine("Error during database generation\n");
			Console.WriteLine(e.Message);
		}
	}
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();

app.Run();