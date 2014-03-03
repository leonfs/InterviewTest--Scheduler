using System;

namespace Interview.Scheduler
{
    public interface IOfficeHoursProvider
    {
        TimeSpan StartTime(DayOfWeek dayOfWeek);
        TimeSpan EndTime(DayOfWeek dayOfWeek);
    }
}
