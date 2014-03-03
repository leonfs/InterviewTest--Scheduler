using System;
using Interview.Scheduler.Calendars;
using NUnit.Framework;

namespace Interview.Scheduler.Tests.Calendars
{
    [TestFixture]
    public class MeetingTests
    {
        private EmployeeId _employeeId;

        [SetUp]
        public void SetUp()
        {
            _employeeId = new EmployeeId("EMP001");
        }

        [Test]
        public void CompareTo_SameDateDifferentStartTime()
        {
            var sameDate = new DateTime(2013, 9, 30);
            var newerMeeting = new Meeting(sameDate, new TimeSpan(14, 0, 0), new TimeSpan(15, 0, 0), _employeeId);

            var olderMeeting = new Meeting(sameDate, new TimeSpan(15, 0, 0), new TimeSpan(16, 0, 0), _employeeId);
            
            Assert.AreEqual(1, olderMeeting.CompareTo(newerMeeting));
            Assert.AreEqual(-1, newerMeeting.CompareTo(olderMeeting));
        }

        [Test]
        public void CompareTo_DifferentDateSameStartTime()
        {
            var newerDate = new DateTime(2013, 9, 29);
            var sameStartTime = new TimeSpan(14, 0, 0);
            var newerMeeting = new Meeting(newerDate, sameStartTime, new TimeSpan(15, 0, 0), _employeeId);

            var olderDate = new DateTime(2013, 9, 30);
            var olderMeeting = new Meeting(olderDate, sameStartTime, new TimeSpan(15, 0, 0), _employeeId);

            Assert.AreEqual(1, olderMeeting.CompareTo(newerMeeting));
            Assert.AreEqual(-1, newerMeeting.CompareTo(olderMeeting));
        }


        /*
         * Should also test IsOverlapped and IsWithinOfficeHours methods.
         */
    }
}
