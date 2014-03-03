using Interview.Scheduler.Calendars;

namespace Interview.Scheduler.Bookings
{
    public interface IBatchProcessor
    {
        Calendar Process(IOfficeHoursProvider officeHoursProvider, IBatch batch);
    }
}