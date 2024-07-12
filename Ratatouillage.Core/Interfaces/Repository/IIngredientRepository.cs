using Ratatouillage.Core.Models;

namespace Ratatouillage.Core.Interfaces.Repository
{
    public interface IIngredientRepository
    {
        Ingredient? GetById(int id);
        IEnumerable<Ingredient> GetAll();
        int Insert(Ingredient ingredient);
        bool Delete(int id);
    }
}
