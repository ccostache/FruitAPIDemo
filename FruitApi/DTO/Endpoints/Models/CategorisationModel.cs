namespace FruitApi.DTO.Endpoints
{
    public class CategorisationModel
    {
        public string Genus { get; set; }
        public string Family { get; set; }

        public CategorisationModel(string Genus, string Family)
        {
            this.Genus = Genus;
            this.Family = Family;
        }

        public CategorisationModel()
        {
        }
    }
}
