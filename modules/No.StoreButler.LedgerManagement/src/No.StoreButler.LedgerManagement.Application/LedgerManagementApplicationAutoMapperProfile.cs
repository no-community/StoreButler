using No.StoreButler.LedgerManagement.LedgerManagement;
using No.StoreButler.LedgerManagement.LedgerManagement.Dtos;
using AutoMapper;

namespace No.StoreButler.LedgerManagement
{
    public class LedgerManagementApplicationAutoMapperProfile : Profile
    {
        public LedgerManagementApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<PayTrade, PayTradeDto>();
            CreateMap<CreatePayTradeInput, PayTrade>(MemberList.Source);
            CreateMap<UpdatePayTradeInput, PayTrade>(MemberList.Source);
            CreateMap<TradeCategory, TradeCategoryDto>();
            CreateMap<CreateTradeCategoryInput, TradeCategory>(MemberList.Source);
            CreateMap<UpdateTradeCategoryInput, TradeCategory>(MemberList.Source);
        }
    }
}
