namespace Ratatouillage.Core.Models
{
    public class Ingredient
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }

    public class IngredientWithQuantity : Ingredient
    {
        public required string Quantity { get; set; }
    }
}
