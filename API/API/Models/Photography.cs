namespace API.Models
{
    public class Photography
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
