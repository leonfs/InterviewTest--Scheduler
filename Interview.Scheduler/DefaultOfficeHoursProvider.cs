using System;

namespace Interview.Scheduler
{
    public class DefaultOfficeHoursProvider : IOfficeHoursProvider
    {
        private readonly TimeSpan _starTime;
        private readonly TimeSpan _endTime;

        public DefaultOfficeHoursProvider(TimeSpan startTime, TimeSpan endTime)
        {
            _starTime = startTime;
            _endTime = endTime;
        }

        public TimeSpan StartTime(DayOfWeek dayOfWeek)
        {
            return _starTime;
        }

        public TimeSpan EndTime(DayOfWeek dayOfWeek)
        {
            return _endTime;
        }
    }
}