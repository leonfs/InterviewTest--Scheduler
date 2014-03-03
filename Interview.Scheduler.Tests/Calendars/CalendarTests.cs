using System;
using Interview.Scheduler.Calendars;
using Moq;
using NUnit.Framework;

namespace Interview.Scheduler.Tests.Calendars
{
    [TestFixture]
    public class CalendarTests
    {
        private Calendar _calendar;
        private Mock<IOfficeHoursProvider> _mockOfficeHoursProvider;

        [SetUp]
        public void SetUp()
        {
            _mockOfficeHoursProvider = new Mock<IOfficeHoursProvider>();
            _mockOfficeHoursProvider.Setup(provider => provider.StartTime(It.IsAny<DayOfWeek>())).Returns(new TimeSpan(9, 0, 0));
            _mockOfficeHoursProvider.Setup(provider => provider.EndTime(It.IsAny<DayOfWeek>())).Returns(new TimeSpan(17, 30, 0));

            _calendar = new Calendar(_mockOfficeHoursProvider.Object);
        }

        [Test]
        public void CreateMeeting_AvailableDateAndWithinOfficeHours_CalendarHasOneMeeting()
        {
            var meetingDate = new DateTime(2013, 9, 20);
            var startTime = new TimeSpan(13, 0, 0); // 1PM or 13HS
            int duration = 2; // 2 HS
            var employeeId = new EmployeeId("EMP001");
        
            Assert.IsEmpty(_calendar.Meetings(meetingDate));

            _calendar.CreateMeeting(meetingDate, startTime, duration, employeeId);

            var today = DateTime.Now;
            Assert.IsEmpty(_calendar.Meetings(today)); //No meetings for today
            Assert.IsNotEmpty(_calendar.Meetings(meetingDate));
        }

        [Test]
        public void CalendarDay()
        {
            var date20130930 = new DateTime(2013, 9, 30);
            var calendarDay = _calendar.CalendarDay(date20130930);

            Assert.AreEqual(2013, calendarDay.Year);
            Assert.AreEqual(9, calendarDay.Month);
            Assert.AreEqual(30, calendarDay.Day);
        }

      
    }
}
