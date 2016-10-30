using AutoMapper;
using itsjustaname_api.Models;

namespace itsjustaname_api
{
    public class SpendMappingConfiguration
    {
        public static void CreateConfig(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<EbayProductModel, SpendModel>()
                .ForMember(dest => dest.LinkToArticle, opt => opt.MapFrom(src => src.ItemUrl));
        }
    }
}