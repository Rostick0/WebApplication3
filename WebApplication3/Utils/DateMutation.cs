namespace WebApplication3.Utils
{
    public class DateGetter(DateTime CreatedDate, DateTime LastModifiedDate)
    {
        public DateTime? CreatedDate { get; protected init; } = CreatedDate;
        public DateTime? LastModifiedDate { get; protected init; } = LastModifiedDate;
    }
    public class DateMutation
    {
        public DateTime CreatedDate { get; private init; }
        public DateTime LastModifiedDate { get; private init; }
        public DateMutation()
        {
            DateTime now = DateTime.Now;
            CreatedDate = now;
            LastModifiedDate = now;
        }
    }

    public class DateMutationUpdated
    {
        public DateTime LastModifiedDate { get; private init; }
        public DateMutationUpdated()
        {
            LastModifiedDate = DateTime.Now;
        }
    }
}
