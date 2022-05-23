namespace Server.Helpers.Events
{
    public class LibMemberEventArgs : EventArgs
    {
        public string MemberId { get; set; } = null!;
        public string? ModifierId { get; set; }
    }
}
