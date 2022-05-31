namespace Server.Helpers.Exceptions
{
    public class UnavailableBookException : Exception
    {
        public UnavailableBookException(string? message) : base(message)
        {
        }
    }
}
