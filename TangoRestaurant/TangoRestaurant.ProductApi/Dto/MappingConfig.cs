using AutoMapper;
using TangoRestaurant.Services.ProductApi.Data.Models;

namespace TangoRestaurant.Services.ProductApi.Dto
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
