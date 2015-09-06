using System;

namespace KPMG.Infrasructure.Helper
{
    public class DateTimeHelper
    {
        public static DateTime CurrentDateTime
        {
            get { return DateTime.UtcNow; }
        }
    }
}
