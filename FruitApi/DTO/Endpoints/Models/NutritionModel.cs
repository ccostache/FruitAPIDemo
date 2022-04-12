namespace FruitApi.DTO.Endpoints
{
    public class NutritionModel
    {
        public string Name { get; set; }
        public string Per { get; set; }
        public string Cals { get; set; }
        public string Protein { get; set; }
        public string Fat { get; set; }
        public string Sugar { get; set; }
        public string Carbs { get; set; }

        public NutritionModel(string Name, string Per, string Cals, string Protein, string Fat, string Sugar, string Carbs)
        {
            this.Name = Name;
            this.Per = Per;
            this.Cals = Cals;
            this.Protein = Protein;
            this.Fat = Fat;
            this.Sugar = Sugar;
            this.Carbs = Carbs;
        }

        public NutritionModel()
        {
        }
    }
}
