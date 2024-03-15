
namespace VirtualGarden;

public class PlantViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public int GardenId { get; set; }

public string PlantImageString { get; set; } = string.Empty;
    public IFormFile? PlantImage { get; set; }
    
    public PlantViewModel() { }

    public PlantViewModel(Plant plant)
    {
        Id = plant.Id;
        Name = plant.Name;
        Description = plant.Description;
        Species = plant.Species;
        PlantImageString = GetPlantImageString(plant.PlantImage);
        GardenId = plant.GardenId;
    }

    private string GetPlantImageString(byte[]? plantImage)
    {
        if (plantImage == null || plantImage.Length == 0)
            return string.Empty;
        return $"data:image/png;base64,{Convert.ToBase64String(plantImage)}";
    }

    public Plant ToPlant()
    {
        return new Plant
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Species = Species,
            PlantImage = GetPlantImage(),
            GardenId = GardenId
        };
    }

    private byte[]? GetPlantImage()
    {
        if (PlantImage == null)
            return null;
        using var memoryStream = new MemoryStream();
        PlantImage.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}
