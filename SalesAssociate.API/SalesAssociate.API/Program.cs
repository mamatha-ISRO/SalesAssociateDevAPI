using SalesAssociate.Repositories;
using Microsoft.EntityFrameworkCore;

void ConfigureHost(ConfigureHostBuilder host)
{
}

// Setup services like database providers, etc.
void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();

    // Setup the database using the ApplicationDbContext
    builder.Services.AddDbContext<SAApplicationDbContext>(options =>
        options.UseNpgsql(  // Connect to the Postgres database
            builder.Configuration.GetConnectionString("DefaultConnection"),
            b =>
            {
                // Configure what project we want to store our Code-First Migrations in
                b.MigrationsAssembly("SalesAssociate.Repositories");
            })
        );

}

// Setup our HTTP request/response pipeline
void ConfigurePipeline(WebApplication app)
{
    //app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    // Run your code
}

// Execute database migrations
void ExecuteMigrations(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<SAApplicationDbContext>();
        context.Database.Migrate();
    }
}

#region
var builder = WebApplication.CreateBuilder(args);

// Setup the application
ConfigureHost(builder.Host);
ConfigureServices(builder);
// Execute migrations on startup
var app = builder.Build();

ExecuteMigrations(app);
// Setup the HTTP pipeline
ConfigurePipeline(app);

app.Run();
#endregion