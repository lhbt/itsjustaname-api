using AutoMapper;
using itsjustaname_api.Models;
using itsjustaname_api.ViewModels;

namespace itsjustaname_api.MappingConfigurations
{
    public class AssetConfiguration
    {
        public static void CreateConfig(IMapperConfigurationExpression cfg)
        {

            cfg.CreateMap<AssetModel, AssetViewModel>();
        }
    }
}