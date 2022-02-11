using AutoMapper;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Models.Dtos;

namespace GeekShopping.ProductAPI.Config
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return autoMapperConfig;
        } 
    }
}
