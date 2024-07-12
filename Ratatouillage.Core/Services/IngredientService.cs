using Ratatouillage.Core.Interfaces.Repository;
using Ratatouillage.Core.Models;

namespace Ratatouillage.Core.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _IngredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _IngredientRepository = ingredientRepository;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _IngredientRepository.GetAll();
        }

        public Ingredient? GetByID(int id)
        {
            return _IngredientRepository.GetById(id);
        }

        public int Insert(Ingredient ingredient)
        {
            return _IngredientRepository.Insert(ingredient);
        }
    }
}
