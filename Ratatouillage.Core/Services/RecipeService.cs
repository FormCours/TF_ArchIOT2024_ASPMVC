using Ratatouillage.Core.Interfaces.Repository;
using Ratatouillage.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratatouillage.Core.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _RecipeRepository;
        private readonly IIngredientRepository _IngredientRepository;

        public RecipeService(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            _RecipeRepository = recipeRepository;
            _IngredientRepository = ingredientRepository;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _RecipeRepository.GetAll();
        }

        public RecipeWithIngredient? GetByID(int id)
        {
            Recipe? recipe = _RecipeRepository.GetById(id);

            if (recipe is null)
                return null;

            List<IngredientWithQuantity> ingredients = _RecipeRepository.GetIngredients(recipe.Id).ToList();

            return new RecipeWithIngredient
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Desc = recipe.Desc,
                Ingredients = ingredients
            };
        }

        public int Insert(RecipeWithIngredient recipe)
        {

            int recipeId = _RecipeRepository.Insert(recipe);

            foreach(IngredientWithQuantity iwq in recipe.Ingredients)
            {
                if(iwq.Id == default)
                {
                    iwq.Id = _IngredientRepository.Insert(iwq);
                }

                _RecipeRepository.AddIngredient(recipeId, iwq.Id, iwq.Quantity);
            }

            return recipeId;
        }
    }
}
