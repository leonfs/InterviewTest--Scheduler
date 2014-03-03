using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Scheduler.Calendars
{
    public class Meeting : IComparable<Meeting>
    {
        

        private readonly DateTime _date;
        private readonly TimeSpan _startTime;
        private readonly TimeSpan _endTime;
        private readonly EmployeeId _employeeId;

        public Meeting(DateTime date, TimeSpan startTime, TimeSpan endTime, EmployeeId employeeId)
        {
            _startTime = startTime;
            _endTime = endTime;
            _date = date.Date;
            _employeeId = employeeId;
        }

        public bool IsOverlapped(IEnumerable<Meeting> meetings)
        {
            return meetings.Any(meeting => meeting.IsOverlapped(this));
        }

        public bool IsOverlapped(Meeting otherMeeting)
        {
            if (_startTime <= otherMeeting._startTime && otherMeeting._startTime <= _endTime) // Upper Boundarie
            {
                return true;
            }
            if (_startTime < otherMeeting._endTime && otherMeeting._endTime <= _endTime) //Lower Boundarie
            {
                return true;
            }
            if (_startTime > otherMeeting._startTime && _endTime < otherMeeting._endTime)
            {
                return true;
            }

            return false;
        }

        public bool IsWithinOfficeHourse(TimeSpan officeHoursStartTime, TimeSpan officeHoursEndTime)
        {
            if (_startTime >= officeHoursStartTime && _endTime <= officeHoursEndTime)
            {
                return true;
            }
            return false;
        }


        public int CompareTo(Meeting other)
        {
            if (this.Date.Equals(other.Date))
            {
                return this.StartTime.CompareTo(other.StartTime);
            }
            return this.Date.CompareTo(other.Date);
        }

        #region Overrides

        protected bool Equals(Meeting other)
        {
            return _date.Equals(other._date) && _startTime.Equals(other._startTime) && _endTime.Equals(other._endTime) && Equals(_employeeId, other._employeeId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Meeting)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _date.GetHashCode();
                hashCode = (hashCode * 397) ^ _startTime.GetHashCode();
                hashCode = (hashCode * 397) ^ _endTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (_employeeId != null ? _employeeId.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

        #region Properties

        public DateTime Date
        {
            get
            {
                return _date;
            }
        }

        public TimeSpan StartTime
        {
            get { return _startTime; }
        }

        public TimeSpan EndTime
        {
            get { return _endTime; }
        }

        public EmployeeId EmployeeId
        {
            get { return _employeeId; }
        }

        #endregion
    }
}