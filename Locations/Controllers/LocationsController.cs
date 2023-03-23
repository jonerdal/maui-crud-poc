using Locations.Contracts;
using Locations.Models;
using Locations.Services;
using Microsoft.AspNetCore.Mvc;

namespace Locations.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationsService _service;

    public LocationsController(ILocationsService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateLocation(CreateLocationRequest request)
    {
        var location = new Location(request.Name, request.Description);

        _service.CreateLocation(location);

        return CreatedAtAction(
            actionName: nameof(CreateLocation),
            routeValues: new { id = location.Id }, //TODO this is added as query param, fix so it is uri path
            value: MapLocationResponse(location));
    }

    [HttpGet()]
    public IActionResult GetLocations()
    {
        var locations = _service.GetAllLocations();

        var locationsResponse = locations.Select(location => MapLocationResponse(location));

        return Ok(locations);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetLocation(Guid Id)
    {
        var location = _service.GetLocation(Id);

        if(location == null)
        {
            return NotFound();
        }

        return Ok(MapLocationResponse(location));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertLocation(Guid Id, UpsertLocationRequest request)
    {
        var location = new Location(request.Name, request.Description) { Id = Id };

        _service.UpsertLocation(location);


        return NoContent(); //TODO return created/nocontent depending on if we create it or not
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteLocation(Guid Id)
    {
        _service.DeleteLocation(Id);

        return NoContent();
    }

    private static LocationResponse MapLocationResponse(Location location)
    {
        return new LocationResponse(location.Id, location.Name, location.Description, location.LastModifiedDateTime);
    }
}
