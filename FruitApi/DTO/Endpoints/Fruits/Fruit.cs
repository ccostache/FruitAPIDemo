namespace FruitApi.DTO.Endpoints.Fruits
{
    public class Fruit
    {
        public string Name { get; set; }

        public Categorisation Categorisation { get; set; }

        public Nutrition Nutrition { get; set; }
    }
}
