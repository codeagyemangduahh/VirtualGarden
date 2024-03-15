using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualGarden.Data;

namespace VirtualGarden;

[Authorize(AuthenticationSchemes = "Identity.Application")]
public class PlantsController : Controller
{
    private readonly ApplicationDbContext _Context;

    public PlantsController(ApplicationDbContext context)
    {
        _Context = context;
    }

    public IActionResult Index(int gardenId)
    {
        var garden = _Context.Gardens.Find(gardenId);
        if (garden == null)
            return NotFound();
        var plants = _Context.Plants.Where(p => p.GardenId == gardenId).ToList();

        if(plants.Count == 0)
            return RedirectToAction("Add", new { gardenId });

        PlantsViewModel plantsViewModel = new PlantsViewModel{
            Plants = plants.Select(p => new PlantViewModel(p)).ToList(),
            GardenId = gardenId
        };
        return View(plantsViewModel);
    }

    public IActionResult Add(int gardenId)
    {
        PlantViewModel plantViewModel = new PlantViewModel { GardenId = gardenId };
        return View("AddOrUpdatePlant", plantViewModel);
    }

    [HttpPost]
    public IActionResult Add(PlantViewModel plantViewModel)
    {
        if (ModelState.IsValid)
        {
            var plant = plantViewModel.ToPlant();
            _Context.Plants.Add(plant);
            _Context.SaveChanges();
            return RedirectToAction("Index", new { gardenId = plantViewModel.GardenId });
        }
        return View("AddOrUpdatePlant", plantViewModel);
    }

    public IActionResult Update(int id)
    {
        var plant = _Context.Plants.Find(id);
        if (plant == null)
            return NotFound();
        var plantViewModel = new PlantViewModel(plant);
        return View("AddOrUpdatePlant", plantViewModel);
    }

    [HttpPost]
    public IActionResult Update(PlantViewModel plantViewModel)
    {
        if (ModelState.IsValid)
        {
            var plant = plantViewModel.ToPlant();
            _Context.Plants.Update(plant);
            _Context.SaveChanges();
            return RedirectToAction("Index", new { gardenId = plantViewModel.GardenId });
        }
        return View("AddOrUpdatePlant", plantViewModel);
    }

    public IActionResult Delete(int id)
    {
        var plant = _Context.Plants.Find(id);
        if (plant == null)
            return NotFound();
        _Context.Plants.Remove(plant);
        _Context.SaveChanges();
        return RedirectToAction("Index", new { gardenId = plant.GardenId });
    }
}

