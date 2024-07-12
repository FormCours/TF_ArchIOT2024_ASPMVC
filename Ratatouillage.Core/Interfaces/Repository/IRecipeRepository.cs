using Ratatouillage.Core.Models;

namespace Ratatouillage.Core.Interfaces.Repository
{
    public interface IRecipeRepository
    {
        Recipe? GetById(int id);
        IEnumerable<Recipe> GetAll();
        int Insert(Recipe recipe);
        bool Update(int id, Recipe data);
        bool Delete(int id);

        bool AddIngredient(int recipeId, int ingredientId, string quantity);
        bool RemoveIngredient(int recipeId, int ingredientId);
        IEnumerable<IngredientWithQuantity> GetIngredients(int recipeId);
    }
}
