using System;
using System.Linq;
using Interview.Scheduler.Bookings;
using Interview.Scheduler.Bookings.Parsers;
using Moq;
using NUnit.Framework;

namespace Interview.Scheduler.Tests.Bookings
{
    [TestFixture]
    public class BatchTest
    {

        private Batch _batch;
        private Mock<IBookingRequestInputParser> _mockBookingRequestInputParser;
        private EmployeeId _employeeId;

        [SetUp]
        public void SetUp()
        {
            _mockBookingRequestInputParser = new Mock<IBookingRequestInputParser>();
            _batch = new Batch(_mockBookingRequestInputParser.Object);

            _employeeId = new EmployeeId("EMP001");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddBookingRequest_NullBookingRequest_ThrowsException()
        {

            BookingRequest bookingRequest = null;
            _batch.AddBookingRequest(bookingRequest);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddBookingRequest_EmptyStringInput_ThrowsException()
        {
            string bookingRequestInput = string.Empty;
            _batch.AddBookingRequest(bookingRequestInput);
        }

        [Test]
        public void AddBookingRequest_SecondBookingRequestHasRecenSubmissionDate_SecondMustBeReturnedFirst()
        {
            Assert.IsEmpty(_batch.BookingRequests);

            var newerSubmissionDate = new DateTime(2013, 09, 30, 17, 20, 00); //2013-09-30 17:20:00
            var newerBookingRequest = new BookingRequest(newerSubmissionDate, _employeeId, 1, DateTime.Now);
            _batch.AddBookingRequest(newerBookingRequest);
            Assert.IsNotEmpty(_batch.BookingRequests);


            var olderSubmissionDate = new DateTime(2013, 09, 30, 17, 15, 00); //2013-09-30 17:15:00
            var olderBookingRequest = new BookingRequest(olderSubmissionDate, _employeeId, 1, DateTime.Now);
            _batch.AddBookingRequest(olderBookingRequest);

            const int expectedBookingRequestCount = 2;
            Assert.AreEqual(expectedBookingRequestCount, _batch.BookingRequests.Count());

            var firstBookingRequestToBeProcessed = _batch.BookingRequests.First();
            Assert.AreEqual(olderBookingRequest, firstBookingRequestToBeProcessed);
        }



    }
}
