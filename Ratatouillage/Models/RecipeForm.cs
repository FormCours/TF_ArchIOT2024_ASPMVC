using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ratatouillage.Models
{
    public class RecipeForm
    {
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z\\s]{2,50}$", ErrorMessage = "Oh c'est dommage 😭")]
        [DisplayName("Le super nom de recette")]
        [DataType(DataType.Text)]
        public required string Name { get; set; }

        [StringLength(1_000)]
        [DisplayName("C'est quoi ?")]
        [DataType(DataType.Password)]
        public required string Desc { get; set; }
    }
}
