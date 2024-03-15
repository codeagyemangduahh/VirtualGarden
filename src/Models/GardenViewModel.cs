namespace VirtualGarden;

public class GardenViewModel
{

    public GardenViewModel()
    {
    }
    public GardenViewModel(Garden garden)
    {
        Id = garden.Id;
        Name = garden.Name;
        Description = garden.Description;
        SquareFootage = garden.SquareFootage;
        SoilType = garden.SoilType;
    }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double SquareFootage { get; set; }

    public SoilType SoilType { get; set; } = SoilType.Loam;

    public int PlantCount { get; set; }
    
    public Garden ToGarden()
    {
        return new Garden
        {
            Id = Id,
            Name = Name,
            Description = Description,
            SquareFootage = SquareFootage,
            SoilType = SoilType
        };
    }
}
