using Microsoft.AspNetCore.Components;

namespace TaskFlow
{
    public class TicketService
    {
        private static List<Ticket> _tickets {  get; set; }
        public static List<Ticket> GetTickets()
        {
            if(_tickets is null)
            {
                _tickets = new List<Ticket>();
                _tickets.Add(new(1, "First Blazor Code", "Week 1 of Roadmap", "Doing", 2));
                _tickets.Add(new(2, "Architecture Course", "Learning more about architrcture and patterns", "To Do", 5));
                _tickets.Add(new(3, "ASP.NET Core Full Course", "ASP.NET Core Full Course", "To Do", 4));
                _tickets.Add(new(4, "Blazor Full Course", "Blazor Full Course", "To Do", 5));
                _tickets.Add(new(5, "Own Project", "TaskFlow Project", "Doing", 5));
            }

            return _tickets;
        }
    }
}
