using Ratatouillage.Core.Models;

namespace Ratatouillage.Core.Interfaces.Repository
{
    public interface IRecipeService
    {
        RecipeWithIngredient? GetByID(int id);
        IEnumerable<Recipe> GetAll();
        int Insert(RecipeWithIngredient ingredient);
    }
}
