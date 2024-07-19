using Ratatouillage.Models;
using static Ratatouillage.Models.RecipeForm;

namespace Ratatouillage.Mappers
{
    public static class IngredientMapper
    {
        public static IngredientViewModel ToViewModel(this Core.Models.Ingredient ingredient)
        {
            return new IngredientViewModel
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };
        }

        public static IngredientRecipeViewModel ToViewModel(this Core.Models.IngredientWithQuantity ingredient)
        {
            return new IngredientRecipeViewModel
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Quantity = ingredient.Quantity
            };
        }

        public static Core.Models.IngredientWithQuantity ToModel(this RecipeIngredientForm ingredient)
        {
            return new Core.Models.IngredientWithQuantity
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Quantity = ingredient.Quantity
            };
        }
    }
}
