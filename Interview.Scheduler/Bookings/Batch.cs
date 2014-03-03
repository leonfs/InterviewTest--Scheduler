using System;
using System.Collections.Generic;
using Interview.Scheduler.Bookings.Parsers;

namespace Interview.Scheduler.Bookings
{
    /// <summary>
    /// Responsable of sorting and grouping all the booking requests by submission date
    /// </summary>
    public class Batch : IBatch 
    {
        private readonly SortedSet<BookingRequest> _bookingRequests;
      
        private readonly IBookingRequestInputParser _bookingRequestInputParser;

        public Batch() : this(new DefaultInputParser())
        {
        }

        public Batch(IBookingRequestInputParser bookingRequestInputParser)
        {
            this._bookingRequests = new SortedSet<BookingRequest>();
            this._bookingRequestInputParser = bookingRequestInputParser;
        }

        public IEnumerable<BookingRequest> BookingRequests
        {
            get { return _bookingRequests; }
        }

        public void AddBookingRequest(BookingRequest bookingRequest)
        {
            if (bookingRequest == null)
            {
                throw new ArgumentNullException("bookingRequest");
            }

            _bookingRequests.Add(bookingRequest);
        }

        public void AddBookingRequest(string bookingRequestInput)
        {
            if (bookingRequestInput.Trim().Equals(string.Empty))
            {
                throw new ArgumentException("bookingRequest");
            }

            var bookingRequest = this._bookingRequestInputParser.Parse(bookingRequestInput);
            AddBookingRequest(bookingRequest);
        }

    }
}