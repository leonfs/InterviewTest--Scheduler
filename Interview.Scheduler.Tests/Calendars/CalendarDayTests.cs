using System;
using System.Linq;
using Interview.Scheduler.Calendars;
using NUnit.Framework;

namespace Interview.Scheduler.Tests.Calendars
{
    [TestFixture]
    public class CalendarDayTests
    {
        private CalendarDay _calendarDay;

        [SetUp]
        public void SetUp()
        {
            var calendarDayDate = new DateTime(2013, 9, 30);
            _calendarDay = new CalendarDay(calendarDayDate, new TimeSpan(9, 0, 0), new TimeSpan(17, 30, 0));
        }

        [Test]
        public void Meetings_NoBookings_EmptyListOfMeetings()
        {
            Assert.IsEmpty(_calendarDay.Meetings);
        }

        [Test]
        public void Book_OneBookingBetweenOfficeHours_OneMeeting()
        {
            Assert.IsEmpty(_calendarDay.Meetings);
            _calendarDay.Book(Hour(12), Hour(13), "EMP001");

            const int expectedMeetings = 1;
            Assert.AreEqual(expectedMeetings, _calendarDay.Meetings.Count());
        }

        [Test]
        public void Book_OneBookingOutsideOfficeHours_EmptyListOfMeetings()
        {
            Assert.IsEmpty(_calendarDay.Meetings);

            _calendarDay.Book(Hour(18), Hour(19), "EMP001");
            Assert.IsEmpty(_calendarDay.Meetings);

            _calendarDay.Book(Hour(16), Hour(18), "EMP002"); //Starts Within office hours, finishes outside
            Assert.IsEmpty(_calendarDay.Meetings);
        }

        [Test]
        public void Book_FiveBookingsOverlapped_OneMeeting()
        {
            const int expectedMeetings = 1;
            Assert.IsEmpty(_calendarDay.Meetings);

            _calendarDay.Book(Hour(13), Hour(16), "EMP001");
            Assert.AreEqual(expectedMeetings, _calendarDay.Meetings.Count());

            _calendarDay.Book(Hour(14), Hour(15), "EMP002"); //Within
            Assert.AreEqual(expectedMeetings, _calendarDay.Meetings.Count());

            _calendarDay.Book(Hour(15), Hour(17), "EMP003"); //Upper Boundary
            Assert.AreEqual(expectedMeetings, _calendarDay.Meetings.Count());

            _calendarDay.Book(Hour(12), Hour(14), "EMP004"); //Lower Boundary
            Assert.AreEqual(expectedMeetings, _calendarDay.Meetings.Count());

            _calendarDay.Book(Hour(12), Hour(17), "EMP005"); //Complete Overlap
            Assert.AreEqual(expectedMeetings, _calendarDay.Meetings.Count());

            _calendarDay.Book(Hour(13), Hour(16), "EMP006"); //Exact Same Time
            Assert.AreEqual(expectedMeetings, _calendarDay.Meetings.Count());
        }

        [Test]
        public void Year()
        {
            const int expectedYear = 2013;
            Assert.AreEqual(expectedYear, _calendarDay.Year);
        }

        [Test]
        public void Month()
        {
            const int expectedMonth = 9; //September
            Assert.AreEqual(expectedMonth, _calendarDay.Month);
        }

        [Test]
        public void Day()
        {
            const int expectedDay = 30; //30th
            Assert.AreEqual(expectedDay, _calendarDay.Day);
        }

        private TimeSpan Hour(int hour)
        {
            return new TimeSpan(hour, 0, 0);
        }

    }
}
