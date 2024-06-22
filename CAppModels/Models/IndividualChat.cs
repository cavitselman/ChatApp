namespace CAppModels.Models
{
    public class IndividualChat
    {
        public int Id { get; set; }
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; }
    }
}
