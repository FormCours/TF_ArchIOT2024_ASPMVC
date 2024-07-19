using Ratatouillage.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ratatouillage.Models
{
    public class RecipeForm
    {
        public class RecipeIngredientForm
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required string Quantity { get; set; }
        }


        [StringLength(50)]
        [RegularExpression("^[a-zA-Z\\s]{2,50}$", ErrorMessage = "Oh c'est dommage 😭")]
        [DisplayName("Le nom de recette")]
        [DataType(DataType.Text)]
        public required string Name { get; set; }

        [StringLength(1_000)]
        [DisplayName("La description")]
        [DataType(DataType.Text)]
        public required string Desc { get; set; }

        public IEnumerable<RecipeIngredientForm> Ingredients { get; set; }

        public RecipeForm()
        {
            // FIXME Add ingredient with form (unfinish)
            Ingredients = new List<RecipeIngredientForm>
            {
                new RecipeIngredientForm { Id= 9, Name= "Eau", Quantity =  "1 l" },
                new RecipeIngredientForm { Id= 0, Name= Guid.NewGuid().ToString(), Quantity =  "Une pincée" },
            };
        }
    }
}
