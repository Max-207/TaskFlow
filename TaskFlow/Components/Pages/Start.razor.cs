using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection.Metadata;

namespace TaskFlow.Components.Pages
{
    public partial class Start
    {
        List<Ticket> _tickets = TicketService.GetTickets();
        private int editingElementId;
        private ElementReference _editingElement;
        private async Task ChangeData(int id, string property)
        {
            Ticket? ticket = _tickets.FirstOrDefault(x => x.id == id);
            if(ticket is null)
            {
                return;
            }

            string value = await JS.InvokeAsync<string>("getValueByInputId", $"{property}_{id}");
            switch(property)
            {
                case "title":
                    ticket.title = value;
                    break;
                case "description":
                    ticket.description = value;
                    break;
                case "status":
                    ticket.status = value;
                    break;
                case "priority":
                    ticket.priority = int.Parse(value);
                    break;
            }
        }

        private void DeleteTicket(int id)
        {
            Ticket? ticket = _tickets.FirstOrDefault(x => x.id == id);
            if (ticket is  not null)
            {
                _tickets.Remove(ticket);
            }
        }

        private async void AddTicket()
        {
            int highestId = _tickets.OrderBy(x => x.id).Last().id;
            Ticket ticket = new Ticket(highestId + 1, null, null, null, null);
            ticket.title = await JS.InvokeAsync<string>("getValueByInputId", "newTicketTitle");
            ticket.description = await JS.InvokeAsync<string>("getValueByInputId", "newTicketDescription");
            ticket.status = await JS.InvokeAsync<string>("getValueByInputId", "newTicketStatus");
            ticket.priority = int.Parse(await JS.InvokeAsync<string>("getValueByInputId", "newTicketPriority"));
            _tickets.Add(ticket);
        }
    }
}
