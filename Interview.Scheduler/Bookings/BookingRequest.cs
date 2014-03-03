using System;

namespace Interview.Scheduler.Bookings
{
    public class BookingRequest : IComparable<BookingRequest>
    {
        
        private readonly DateTime _meetingDateTime;

        public BookingRequest(DateTime submissionTime, EmployeeId employeeId, int meetingDuration, DateTime meetingDateTime)
        {
            SubmissionTime = submissionTime;
            EmployeeId = employeeId;
            MeetingDuration = meetingDuration;
            _meetingDateTime = meetingDateTime;
        }

        public DateTime SubmissionTime
        {
            get;  private set;
        }

        public EmployeeId EmployeeId
        {
            get; private set; 
        }

        public int MeetingDuration
        {
            get; private set;
        }

        public DateTime MeetingDate
        {
            get { return _meetingDateTime.Date; }
        }

        public TimeSpan MeetingStartTime
        {
            get { return _meetingDateTime.TimeOfDay; }
        }

        public int CompareTo(BookingRequest other)
        {
            return SubmissionTime.CompareTo(other.SubmissionTime);
        }


        protected bool Equals(BookingRequest other)
        {
            return _meetingDateTime.Equals(other._meetingDateTime) && SubmissionTime.Equals(other.SubmissionTime) && Equals(EmployeeId, other.EmployeeId) && MeetingDuration == other.MeetingDuration;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BookingRequest)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _meetingDateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ SubmissionTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (EmployeeId != null ? EmployeeId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ MeetingDuration;
                return hashCode;
            }
        }
    }
}