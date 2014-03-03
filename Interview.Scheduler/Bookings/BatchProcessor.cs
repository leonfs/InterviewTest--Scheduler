using Interview.Scheduler.Calendars;

namespace Interview.Scheduler.Bookings
{
    public class BatchProcessor
    {
        
        public Calendar Process(IOfficeHoursProvider officeHoursProvider, IBatch batch)
        {
            var calendar = new Calendar(officeHoursProvider);

            foreach(var bookingRequest in batch.BookingRequests)
            {
                calendar.CreateMeeting(bookingRequest.MeetingDate, bookingRequest.MeetingStartTime, bookingRequest.MeetingDuration, bookingRequest.EmployeeId);
            }

            return calendar;
        }


    }
}
