using System.Linq;
using AutoMapper;
using itsjustaname_api.Models;
using itsjustaname_api.ViewModels;

namespace itsjustaname_api.MappingConfigurations
{
    public class TransactionMappingConfiguration
    {
        public static void CreateTransactionMappingLogic(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TransactionModel, TransactionViewModel>()
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src => src.CreditOrDebit.ToLower() == "credit" ? "credit" : "debit"))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => MapName(src)));
            cfg.CreateMap<DailyTransactionBlockModel, DailyTransactionBlockViewModel>()
                .ForMember(dest => dest.AvgSpend,
                    opt => opt.MapFrom(src => src.Transactions.Where(t => t.Amount < 0).Average(t => t.Amount)))
                .ForMember(dest => dest.AvgReceived,
                    opt => opt.MapFrom(src => src.Transactions.Where(t => t.Amount > 0).Average(t => t.Amount)));
        }

        private static string MapName(TransactionModel src)
        {
            if (src.Merchant != string.Empty)
            {
                return src.Merchant;
            }
            return src.Category;
        }
    }
}