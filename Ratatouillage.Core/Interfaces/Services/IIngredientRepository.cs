using Ratatouillage.Core.Models;

namespace Ratatouillage.Core.Interfaces.Repository
{
    public interface IIngredientService
    {
        Ingredient? GetByID(int id);
        IEnumerable<Ingredient> GetAll();
        int Insert(Ingredient ingredient);
    }
}
