using PokemonGO_Backend.Domain.Enums;

namespace PokemonGO_Backend.Contract.DTOs
{
    public class LogDataDTO
    {
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public string? Source { get; set; }
        public int? UserId { get; set; }
        public string? RequestId { get; set; }
    }
}
