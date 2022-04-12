using FruitApi.DTO.Endpoints.Fruits;

namespace FruitApi.DTO.Endpoints.Mapping
{
    /// <summary>
    /// FruitProfile represents a mapping of the fruit data received from the 2 services into the FruitModel
    /// </summary>
    public class FruitProfileService : AutoMapper.Profile
    {
        public FruitProfileService()
        {
            CreateMap<FruitModel, Fruit>()
                .ForMember(mappingKey => mappingKey.Name, options => options.MapFrom(source => source.Name))
                .ForPath(destination => destination.Categorisation.Genus, options => options.MapFrom(source => source.Categorisation.Genus))
                .ForPath(destination => destination.Categorisation.Family, options => options.MapFrom(source => source.Categorisation.Family))
                .ForPath(destination => destination.Nutrition.Name, options => options.MapFrom(source => source.Nutrition.Name))
                .ForPath(destination => destination.Nutrition.Per, options => options.MapFrom(source => source.Nutrition.Per))
                .ForPath(destination => destination.Nutrition.Cals, options => options.MapFrom(source => source.Nutrition.Cals))
                .ForPath(destination => destination.Nutrition.Protein, options => options.MapFrom(source => source.Nutrition.Protein))
                .ForPath(destination => destination.Nutrition.Fat, options => options.MapFrom(source => source.Nutrition.Fat))
                .ForPath(destination => destination.Nutrition.Sugar, options => options.MapFrom(source => source.Nutrition.Sugar))
                .ForPath(destination => destination.Nutrition.Carbs, options => options.MapFrom(source => source.Nutrition.Carbs));
        }        
    }
}
