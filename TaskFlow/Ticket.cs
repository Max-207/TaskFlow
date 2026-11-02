namespace TaskFlow
{
    public class Ticket
    {
        public int id {  get; set; }
        public string? title {  get; set; }
        public string? description {  get; set; }
        public string? status {  get; set; }
        public int? priority {  get; set; }
        public Ticket(int id, string? title, string? description, string? status, int? priority)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.status = status;
            this.priority = priority;
        }
    }
}
