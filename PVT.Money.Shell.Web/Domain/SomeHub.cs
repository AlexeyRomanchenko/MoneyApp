using Microsoft.AspNetCore.SignalR;

namespace PVT.Money.Shell.Web
{
    public class SomeHub : Hub 
    {
        public void Receive(string message)
        {
            Clients.All.InvokeAsync("Send", message);
        }

    }
}