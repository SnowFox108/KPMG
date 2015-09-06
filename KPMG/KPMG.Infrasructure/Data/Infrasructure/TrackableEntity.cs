using System;

namespace KPMG.Infrasructure.Data.Infrasructure
{
    public class TrackableEntity : Entity, ITrackable
    {
        public DateTime CreatedDate { get; set; }
    }
}
