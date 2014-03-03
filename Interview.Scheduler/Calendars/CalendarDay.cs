using System;
using System.Collections.Generic;

namespace Interview.Scheduler.Calendars
{
    public class CalendarDay : IComparable<CalendarDay>
    {
        private DateTime _date;
        private readonly TimeSpan _officeHoursStartTime;
        private readonly TimeSpan _officeHoursEndTime;
        private SortedSet<Meeting> _meetings;

        public CalendarDay(DateTime date, TimeSpan officeHoursStartTime, TimeSpan officeHoursEndTime)
        {
            _date = date;
            _officeHoursStartTime = officeHoursStartTime;
            _officeHoursEndTime = officeHoursEndTime;
            _meetings = new SortedSet<Meeting>();
        }

        public int CompareTo(CalendarDay other)
        {
            return _date.CompareTo(other._date);
        }
        

        public void Book(TimeSpan startTime, TimeSpan endTime, string employeeId)
        {
            var meeting = new Meeting(this._date, startTime, endTime, new EmployeeId(employeeId));
            if (meeting.IsWithinOfficeHourse(_officeHoursStartTime, _officeHoursEndTime) && !meeting.IsOverlapped(_meetings))
            {
                _meetings.Add(meeting);
            }
        }

        #region Overrides 

        protected bool Equals(CalendarDay other)
        {
            return _date.Equals(other._date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CalendarDay)obj);
        }

        public override int GetHashCode()
        {
            return _date.GetHashCode();
        }


        #endregion

        #region Properties

        public int Year
        {
            get { return _date.Year; }
        }

        public int Month
        {
            get { return _date.Month; }
        }

        public int Day
        {
            get { return _date.Day; }
        }

        public IEnumerable<Meeting> Meetings
        {
            get { return _meetings; }
        }

        #endregion
    }
}