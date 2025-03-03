using Entity.Enums;
using System.Text.Json.Serialization;

namespace Application.Entity
{
    public class RequestDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }
        [JsonPropertyName("status")]
        public RequestStatus Status { get; set; }
        [JsonPropertyName("assignments")]
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
