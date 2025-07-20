namespace PokemonGO_Backend.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string City { get; set; }
        public string Region { get; set; }    
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    
}