using System;

namespace KPMG.Infrastructure.Data.Infrasructure
{
    public class TrackableEntity : Entity, ITrackable
    {
        public DateTime CreatedDate { get; set; }
    }
}
