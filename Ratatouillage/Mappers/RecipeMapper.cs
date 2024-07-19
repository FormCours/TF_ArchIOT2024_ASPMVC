using Ratatouillage.Core.Models;
using Ratatouillage.Models;

namespace Ratatouillage.Mappers
{
    public static class RecipeMapper
    {
        public static RecipeViewModel ToViewModel(this Core.Models.Recipe recipe)
        {
            return new RecipeViewModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
            };
        }

        public static RecipeDetailViewModel ToViewModel(this Core.Models.RecipeWithIngredient recipe)
        {
            return new RecipeDetailViewModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Desc = recipe.Desc,
                Ingredients = recipe.Ingredients.Select(i => i.ToViewModel()),
            };
        }

        public static Core.Models.RecipeWithIngredient ToModel(this RecipeForm recipe)
        {
            return new RecipeWithIngredient
            {
                Id = 0,
                Name = recipe.Name,
                Desc = recipe.Desc,
                Ingredients = recipe.Ingredients.Select(i => i.ToModel()),
            };
        } 
    }
}
