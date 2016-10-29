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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => MapName(src)))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount / 100))
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());

            cfg.CreateMap<DailyTransactionBlockModel, DailyTransactionBlockViewModel>()
                .ForMember(dest => dest.TotalSpent,
                    opt => opt.MapFrom(src => src.Transactions.Where(t => t.SignedAmount < 0).Sum(t => t.Amount) / 100))
                .ForMember(dest => dest.TotalReceived,
                    opt => opt.MapFrom(src => src.Transactions.Where(t => t.SignedAmount > 0).Sum(t => t.Amount) / 100))
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date.Value.ToString("D")));

            cfg.CreateMap<SummaryModel, SummaryViewModel>();
        }

        private static string MapName(TransactionModel src)
        {
            if (src.Merchant != string.Empty)
            {
                return src.Merchant;
            }
            if (src.Category != "Uncategorized")
            {
                return src.Category;
            }
            return src.Description;
        }
    }
}