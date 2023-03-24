namespace Locations.Models
{
    public class Location
    {
        public Location(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            LastModifiedDateTime = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
