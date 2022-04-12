using System.ComponentModel.DataAnnotations;

namespace FruitApi.DTO.Endpoints
{
    public class FruitModel
    {
        /// <summary>
        /// The fruit name used as the unique identifier
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fruit name must not be null or empty")]
        [MinLength(3, ErrorMessage = "Fruit name cannot be less than 3 characters")]
        [MaxLength(20, ErrorMessage = "Fruit name cannot be more than 20 characters")]
        public string Name { get; set; }

        public CategorisationModel Categorisation { get; set; }

        public NutritionModel Nutrition { get; set; }

        public FruitModel(string Name, CategorisationModel categorisation, NutritionModel nutrition)
        {
            this.Name = Name;
            this.Categorisation = categorisation;
            this.Nutrition = nutrition;
        }

        public FruitModel()
        {
        }
    }
}
