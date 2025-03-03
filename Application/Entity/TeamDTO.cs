
using Entity.Enums;
using System.Text.Json.Serialization;

namespace Application.Entity
{
    public class TeamDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("typeBrigade")]
        public TypeTeam TypeBrigade { get; set; }
    }
}
