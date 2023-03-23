using Locations.Persistence;
using Locations.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); 
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<ILocationsService, LocationsService>();
    builder.Services.AddDbContext<LocationDbContext>(options => options.UseSqlite("Data Source=Locations.db"));
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}