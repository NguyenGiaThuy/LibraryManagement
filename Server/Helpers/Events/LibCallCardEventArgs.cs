namespace Server.Helpers.Events
{
    public class LibCallCardEventArgs : EventArgs
    {
        public string CallCardId { get; set; } = null!;
        public int? Status { get; set; }
    }
}
