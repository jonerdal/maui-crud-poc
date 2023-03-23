namespace Locations.Contracts
{
    public record LocationResponse(
        Guid Id, 
        string Name, 
        string Description,
        DateTime LastModifiedDateTime);
}
