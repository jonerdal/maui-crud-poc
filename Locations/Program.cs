using Locations.Services;

var builder = WebApplication.CreateBuilder(args); 
{
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ILocationsService, LocationsService>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}