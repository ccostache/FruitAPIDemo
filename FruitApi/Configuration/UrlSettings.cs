namespace FruitApi.Configuration
{
    /// <summary>
    /// Gets the url addresses of the outbound services from the appsettings json file
    /// </summary>
    public class UrlSettings
    {
        public const string SectionName = "FruitApiUrlSettings";
        public string FruitInfoUrl { get; set; }
        public string FruitNutritionsUrl { get; set; }
    }
}
