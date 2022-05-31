namespace Server.Helpers.Exceptions
{
    public class ExpiredMembershipException : Exception
    {
        public ExpiredMembershipException(string? message) : base(message)
        {
        }
    }
}
