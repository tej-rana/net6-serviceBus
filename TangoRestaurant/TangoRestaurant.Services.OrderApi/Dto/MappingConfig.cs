using AutoMapper;

namespace TangoRestaurant.Services.OrderApi.Dto
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {


            });

            return mappingConfig;
        }
    }
}
