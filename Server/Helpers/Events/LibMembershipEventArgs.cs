namespace Server.Helpers.Events
{
    public class LibMembershipEventArgs : EventArgs
    {
        public string MembershipId { get; set; } = null!;
        public string socialId { get; set; } = null!;
    }
}
