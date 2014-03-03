namespace Interview.Scheduler
{
    public class EmployeeId
    {
        private readonly string _id;

        public EmployeeId(string value)
        {
            this._id = value;
        }

        protected bool Equals(EmployeeId other)
        {
            return string.Equals(_id, other._id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EmployeeId) obj);
        }

        public override int GetHashCode()
        {
            return (_id != null ? _id.GetHashCode() : 0);
        }


    }

   
}