using AutoMapper;
using itsjustaname_api.MappingConfigurations;

namespace itsjustaname_api
{
    public class MapperConfig
    {
        public static IMapper Initialise()
        {
            var config = new MapperConfiguration(CreateConfig);
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            return mapper;
        }

        private static void CreateConfig(IMapperConfigurationExpression cfg)
        {
            TransactionMappingConfiguration.CreateTransactionMappingLogic(cfg);
            SpendMappingConfiguration.CreateConfig(cfg);
        }
    }
}