using AutoMapper;
using KPMG.Infrastructure.Data.Entity;
using KPMG.Infrastructure.Data.Model;
using KPMG.Infrastructure.Helper;

namespace KPMG.Infrastructure.Data.MappingProfile
{
    public class TransactionDataProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TransactionData, TransactionDataDto>();
        }
    }
}
