using System.Collections.Generic;

namespace Interview.Scheduler.Bookings
{
    public interface IBatch
    {
        IEnumerable<BookingRequest> BookingRequests { get; }
    }
}