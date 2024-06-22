namespace CApp.Client.AppStates
{
    public class AvailableUserState
    {
        public string ReceiverId { get; private set; } = string.Empty;
        public string Fullname { get; private set; } = string.Empty;

        public void SetStates(string fullname, string receiverId)
        {
            Fullname = fullname;
            ReceiverId = receiverId;
        }
    }
}
