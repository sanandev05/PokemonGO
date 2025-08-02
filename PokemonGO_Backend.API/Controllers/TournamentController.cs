using Microsoft.AspNetCore.Mvc;

namespace PokemonGO_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : Controller
    {
        [HttpPost]
        public Task<IActionResult> JoinTournament(int tournamentId, int trainerId)
        {
            // Logic to join a tournament
            // This is a placeholder implementation
            return Task.FromResult<IActionResult>(Ok($"Trainer {trainerId} joined tournament {tournamentId}"));
        }
    }
}
