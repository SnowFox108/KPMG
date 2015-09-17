using System;

namespace KPMG.Infrastructure.Data.Infrasructure
{
    public interface ITrackable
    {
        DateTime CreatedDate { get; set; }
    }
}
