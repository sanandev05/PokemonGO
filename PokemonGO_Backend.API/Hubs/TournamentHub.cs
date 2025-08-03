using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace PokemonGO_Backend.API.Hubs
{
    public class TournamentHub : Hub
    {
        private static readonly HashSet<string> playersInTournament = new HashSet<string>();

        public async Task JoinTournament(string userName)
        {
            if (playersInTournament.Add(userName))
            {
                Console.WriteLine($"Player '{userName}' joined the tournament zone.");

                await Clients.All.SendAsync("ReceiveTournamentPlayers", playersInTournament.ToList());
            }
        }
        public async Task LeaveTournament(string userName)
        {
            if (playersInTournament.Remove(userName))
            {
                Console.WriteLine($"Player '{userName}' left the tournament zone.");

                await Clients.All.SendAsync("ReceiveTournamentPlayers", playersInTournament.ToList());
            }
        }

        public async Task StartBattle()
        {
            if (playersInTournament.Count == 2)
            {
                Console.WriteLine("Starting battle with 2 players.");

                await Clients.All.SendAsync("StartBattle");

                playersInTournament.Clear();
            }
            else
            {
                Console.WriteLine("Battle cannot start, not enough players.");
            }
        }
    }
}
