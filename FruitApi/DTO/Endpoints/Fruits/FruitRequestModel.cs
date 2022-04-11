using System.ComponentModel.DataAnnotations;

namespace FruitApi.DTO.Endpoints
{
    public class FruitRequestModel
    {
        /// <summary>
        /// The fruit name used as the unique identifier
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fruit name must not be null or empty")]
        [MinLength(3, ErrorMessage = "Fruit name cannot be less than 3 characters")]
        [MaxLength(20, ErrorMessage = "Fruit name cannot be more than 20 characters")]
        public string Name { get; set; }

        public CategorisationModel Categorsation { get; set; }

        public NutritionModel Nutrition { get; set; }
    }
}
