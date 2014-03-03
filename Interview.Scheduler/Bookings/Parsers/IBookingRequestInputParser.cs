namespace Interview.Scheduler.Bookings.Parsers
{
    public interface IBookingRequestInputParser
    {
        BookingRequest Parse(string bookingRequestInput);
    }
}
