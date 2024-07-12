namespace Ratatouillage.Core.Models
{
    public class Recipe
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Desc { get; set; }
    }

    public class RecipeWithIngredient : Recipe
    {
        public required List<IngredientWithQuantity> Ingredients { get; set; }
    }
}
