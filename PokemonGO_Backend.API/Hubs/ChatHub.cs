using Microsoft.AspNetCore.SignalR;

namespace PokemonGO_Backend.API.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // Send the message to all connected clients
            Console.WriteLine($"📥 {user} typed: {message}");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        
    }
}
