using AutoMapper;
using TangoRestaurant.ProductApi.Data.Models;

namespace TangoRestaurant.ProductApi.Dto
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();

            });

            return mappingConfig;
        }
    }
}
