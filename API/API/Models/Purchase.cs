namespace API.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public State State { get; set; }
    }
    public enum State
    {
        Pending,
        Paid,
        Sent,
        Delivery,
        Closed
    }
}
