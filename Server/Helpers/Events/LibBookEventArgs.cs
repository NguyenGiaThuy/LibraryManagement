namespace Server.Helpers.Events
{
    public class LibBookEventArgs : EventArgs
    {
        public string BookId { get; set; } = null!;
        public string? ReceiverId { get; set; }
        public string? ModifierId { get; set; }
    }
}
