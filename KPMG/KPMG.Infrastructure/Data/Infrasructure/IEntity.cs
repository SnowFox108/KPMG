using System;

namespace KPMG.Infrastructure.Data.Infrasructure
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
