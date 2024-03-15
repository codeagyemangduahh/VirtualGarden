namespace VirtualGarden;

public class Plant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public byte[]? PlantImage { get; set; }
    public int GardenId { get; set; }
}
