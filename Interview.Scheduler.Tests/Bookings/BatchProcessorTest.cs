using Interview.Scheduler.Bookings;
using Moq;
using NUnit.Framework;

namespace Interview.Scheduler.Tests.Bookings
{
    public class BatchProcessorTest
    {
        private BatchProcessor _batchProcessor;
        private Mock<IOfficeHoursProvider> _mockOfficeHoursProvider;

        [SetUp]
        public void SetUp()
        {
            _mockOfficeHoursProvider = new Mock<IOfficeHoursProvider>();


            _batchProcessor = new BatchProcessor();
        }
        
        [Test]
        public void Process_EmtyBatch_NotNullBookingCalendarWithoutMeetings()
        {
            var batch = new Batch();
            var bookingCalendar = _batchProcessor.Process(_mockOfficeHoursProvider.Object, batch);

            Assert.NotNull(bookingCalendar);
            Assert.IsFalse(bookingCalendar.HasCalendarDays());
        }

        /*
         * More tests should be written for the processor but I think that there are plenty of unit tests
         * that show my testing methodology
         */


    }
}
