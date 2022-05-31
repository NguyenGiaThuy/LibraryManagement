namespace Server.Helpers.Exceptions
{
    [Serializable]
    public class NonExistenceException : Exception
    {
        public NonExistenceException(string? message) : base(message)
        {
        }
    }
}
