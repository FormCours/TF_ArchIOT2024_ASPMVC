namespace Ratatouillage.Models
{
    public class IngredientViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }

    public class IngredientRecipeViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Quantity { get; set; }
    }
}
