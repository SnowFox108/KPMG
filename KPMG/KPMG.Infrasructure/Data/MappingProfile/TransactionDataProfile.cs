using AutoMapper;
using KPMG.Infrasructure.Data.Entity;
using KPMG.Infrasructure.Data.Model;
using KPMG.Infrasructure.Helper;

namespace KPMG.Infrasructure.Data.MappingProfile
{
    public class TransactionDataProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TransactionData, TransactionDataDto>()
                .IgnoreAllMissingInTarget();
        }
    }
}
