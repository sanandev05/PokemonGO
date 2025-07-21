using PokemonGO_Backend.Domain.Enums;

namespace PokemonGO_Backend.Domain.Entities
{
    public class LogData : BaseEntity
    {
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public string? Source { get; set; }
        public int? UserId { get; set; }
        public string? RequestId { get; set; }
    }
}
