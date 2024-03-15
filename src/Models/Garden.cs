namespace VirtualGarden;

public class Garden
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double SquareFootage { get; set; }

    public Gardener Gardener { get; set; } = null!;

    public SoilType SoilType { get; set; } = SoilType.Loam;
    public List<Plant> Plants { get; set; } = null!;
}
