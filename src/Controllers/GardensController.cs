using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirtualGarden.Data;

namespace VirtualGarden;

[Authorize(AuthenticationSchemes = "Identity.Application")]
public class GardensController : Controller
{
    private readonly ApplicationDbContext _Context;
    private readonly UserManager<Gardener> _UserManager;

    public GardensController(ApplicationDbContext context, UserManager<Gardener> userManager)
    {
        _Context = context;
        _UserManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var gardener = await _UserManager.GetUserAsync(User);
        var gardens = _Context.Gardens.Where(g => g.Gardener.Equals(gardener)).ToList();
        if (gardens.Count == 0)
            return RedirectToAction("Add");
        GardensViewModel gardensViewModel = new GardensViewModel
        {
            Gardens = gardens
                .Select(g => new GardenViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    SquareFootage = g.SquareFootage,
                    SoilType = g.SoilType,
                    PlantCount = g.Plants?.Count ?? 0,
                })
                .ToList()
        };
        return View(gardensViewModel);
    }

    public IActionResult Add()
    {
        return View("AddOrUpdateGarden");
    }

    [HttpPost]
    public async Task<IActionResult> Add(GardenViewModel gardenViewModel)
    {
        if (ModelState.IsValid)
        {
            var garden = gardenViewModel.ToGarden();
            var gardener = await _UserManager.GetUserAsync(User);

            if (gardener == null)
                return RedirectToAction("Login", "Account");

            garden.Gardener = gardener;
            _Context.Gardens.Add(garden);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("AddOrUpdateGarden");
    }

    public IActionResult Edit(int id)
    {
        var garden = _Context.Gardens.FirstOrDefault(g => g.Id == id);
        if (garden == null)
            return RedirectToAction("Index");
        return View("AddOrUpdateGarden", new GardenViewModel(garden));
    }

    [HttpPost]
    public IActionResult Edit(GardenViewModel gardenViewModel)
    {
        if (ModelState.IsValid)
        {
            var garden = gardenViewModel.ToGarden();
            _Context.Gardens.Update(garden);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("AddOrUpdateGarden");
    }

    public IActionResult Delete(int id)
    {
        var garden = _Context.Gardens.FirstOrDefault(g => g.Id == id);
        if (garden == null)
            return RedirectToAction("Index");
        _Context.Gardens.Remove(garden);
        _Context.SaveChanges();
        return RedirectToAction("Index");
    }
}
