using System;
using Interview.Scheduler.Bookings.Parsers;
using NUnit.Framework;

namespace Interview.Scheduler.Tests.Bookings
{
    [TestFixture]
    public class DefaultInputParserTest
    {
        private readonly string _completeInput = "2011-03-17 10:17:06 EMP001" + Environment.NewLine + "2011-03-21 09:00 1";
        private DefaultInputParser _defaultInputParser;

        [SetUp]
        public void SetUp()
        {
            _defaultInputParser = new DefaultInputParser();
        }
        
        [Test]
        public void Parse_ValidSubmissionTime()
        {
            var bookingRequest = _defaultInputParser.Parse(_completeInput);
            var expectedSubmissionTime = new DateTime(2011, 3, 17, 10, 17, 06);
            Assert.AreEqual(expectedSubmissionTime, bookingRequest.SubmissionTime);
        }

        [Test]
        public void Parse_ValidEmployeeId()
        {
            var bookingRequest = _defaultInputParser.Parse(_completeInput);
            var expectedEmployeeId = new EmployeeId("EMP001");
            Assert.AreEqual(expectedEmployeeId, bookingRequest.EmployeeId);
        }

        [Test]
        public void Parse_ValidMeetingDuration()
        {
            var bookingRequest = _defaultInputParser.Parse(_completeInput);
            const int expectedMeetingDuration = 1;
            Assert.AreEqual(expectedMeetingDuration, bookingRequest.MeetingDuration);
        }

        [Test]
        public void Parse_MeetingStartTime()
        {
            //2011-03-21 09:00
            var bookingRequest = _defaultInputParser.Parse(_completeInput);
            var expectedMeetingStartTime = new TimeSpan(9, 0, 0);
            Assert.AreEqual(expectedMeetingStartTime, bookingRequest.MeetingStartTime);
        }
    }
}
