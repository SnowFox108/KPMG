using System;

namespace KPMG.Infrastructure.Helper
{
    public class DateTimeHelper
    {
        public static DateTime CurrentDateTime
        {
            get { return DateTime.UtcNow; }
        }
    }
}
