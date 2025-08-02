using Microsoft.AspNetCore.SignalR;

namespace PokemonGO_Backend.API.Hubs
{
    public class GameHub : Hub
    {
        public async Task UpdatePlayerState(
       string userName,
       float posX, float posY, float posZ,
       float rotX, float rotY, float rotZ,
       string animationState)
        {
            await Clients.Others.SendAsync(
                "ReceivePlayerState",
                userName,
                posX, posY, posZ,
                rotX, rotY, rotZ,
                animationState);
        }
    }
}
