using Microsoft.AspNetCore.Mvc;
using Ratatouillage.Core.Interfaces.Repository;
using Ratatouillage.Core.Models;
using Ratatouillage.Models;
using System.Diagnostics;

namespace Ratatouillage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRecipeService _RecipeService;

        public HomeController(ILogger<HomeController> logger, IRecipeService recipeService)
        {
            _logger = logger;
            _RecipeService = recipeService;
        }

        public IActionResult Index()
        {
            IEnumerable<Recipe> recipes = _RecipeService.GetAll();
            return View(recipes);
        }

        public IActionResult Detail([FromRoute] int id)
        {
            RecipeWithIngredient? recipe = _RecipeService.GetByID(id);

            if( recipe is null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RecipeForm recipeForm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            _RecipeService.Insert(new RecipeWithIngredient
            {
                // TODO : Faire le mapping dans une méthode (=> Dossier "Mapper" par exemple)
                Id = 0,
                Name = recipeForm.Name,
                Desc = recipeForm.Desc,
                Ingredients = new List<IngredientWithQuantity>
                {
                    new IngredientWithQuantity { Id= 9, Name= "Eau", Quantity =  "1 l" },
                    new IngredientWithQuantity { Id= 0, Name= "Inconnue", Quantity =  "Une pincée" },
                }
            });

            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
