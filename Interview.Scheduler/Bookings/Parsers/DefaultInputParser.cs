using System;
using System.Globalization;

namespace Interview.Scheduler.Bookings.Parsers
{
    public class DefaultInputParser : IBookingRequestInputParser
    {
        private const string InvalidFormatExceptionMsg = "Invalid booking request input format.";
        private readonly string _dateFormat = "yyyy-MM-dd hh:mm:ss";

        public DefaultInputParser()
        {
            
        }

        public DefaultInputParser(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        public BookingRequest Parse(string bookingRequestInput)
        {
            var lines = bookingRequestInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length != 2)
            {
                throw new FormatException(InvalidFormatExceptionMsg);
            }

            var firstLine = lines[0];
            var firstLineValues = firstLine.Split(' ');

            if (firstLineValues.Length != 3)
            {
                throw new FormatException(InvalidFormatExceptionMsg);
            }

            var submissionTimeValue = firstLineValues[0] + ' ' + firstLineValues[1];
            var submissionTime = DateTime.ParseExact(submissionTimeValue, _dateFormat, CultureInfo.InvariantCulture);

            var employeeIdValue = firstLineValues[2];
            var employeeId = new EmployeeId(employeeIdValue);


            var secondLine = lines[1];
            var secondLineValues = secondLine.Split(' ');
            if (secondLineValues.Length != 3)
            {
                throw new FormatException(InvalidFormatExceptionMsg);
            }

            var meetingDurationValue = secondLineValues[2];
            var meetingDuration = int.Parse(meetingDurationValue);

            var meetingSartTimeValue = secondLineValues[0] + ' ' + secondLineValues[1];
            var meetingStartTime = DateTime.Parse(meetingSartTimeValue);

            return new BookingRequest(submissionTime, employeeId, meetingDuration, meetingStartTime);
        }


    }
}