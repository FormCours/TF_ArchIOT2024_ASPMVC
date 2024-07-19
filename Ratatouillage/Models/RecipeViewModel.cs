namespace Ratatouillage.Models
{
    public class RecipeViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
    public class RecipeDetailViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Desc { get; set; }
        public required IEnumerable<IngredientRecipeViewModel> Ingredients { get; set; }
    }
}
