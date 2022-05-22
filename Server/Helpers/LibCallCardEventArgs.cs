namespace Server.Helpers
{
    public class LibCallCardEventArgs : EventArgs
    {
        public string CallCardId { get; set; }
        public int Status { get; set; }
    }
}
