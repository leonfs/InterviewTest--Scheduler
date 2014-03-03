using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Scheduler.Calendars
{
    public class Calendar
    {
        private readonly SortedSet<CalendarDay> _calendarDays;
        private readonly IOfficeHoursProvider _officeHoursProvider;

        public Calendar(IOfficeHoursProvider officeHoursProvider)
        {
            if (officeHoursProvider == null)
            {
                throw new ArgumentNullException("officeHoursProvider");
            }

            _officeHoursProvider = officeHoursProvider;

            _calendarDays = new SortedSet<CalendarDay>();
        }

        public void CreateMeeting(DateTime meetingDate, TimeSpan startTime, int meetingDuration, EmployeeId employeeId)
        {
            var calendarDay = CalendarDay(meetingDate);
            var endTime = startTime.Add(new TimeSpan(meetingDuration));
            calendarDay.Book(startTime, endTime, employeeId.ToString());
        }

        public IEnumerable<Meeting> Meetings(DateTime calendarDayDate)
        {
            var calendarDay = CalendarDay(calendarDayDate);
            return calendarDay.Meetings;
        }
 
        public CalendarDay CalendarDay(DateTime calendarDayDate)
        {
            var date = calendarDayDate.Date;

            CalendarDay calendarDay = _calendarDays.FirstOrDefault(d => d.Year == date.Year && d.Month == date.Month && d.Day == date.Day);
        
            if (calendarDay == null)
            {
                calendarDay = new CalendarDay(date, _officeHoursProvider.StartTime(date.DayOfWeek), _officeHoursProvider.EndTime(date.DayOfWeek));
                _calendarDays.Add(calendarDay);
            }

            return calendarDay;
        }

        public bool HasCalendarDays()
        {
            if (_calendarDays.Count > 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<CalendarDay> CalendaryDays
        {
            get { return _calendarDays; }
        }
    }
}