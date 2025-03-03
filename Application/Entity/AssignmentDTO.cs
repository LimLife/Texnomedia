using Entity.Enums;
using System.Text.Json.Serialization;

namespace Application.Entity
{
    public class AssignmentDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("assignmentDate")]
        public DateTime AssignmentDate { get; set; }
        [JsonPropertyName("completionDate")]
        public DateTime CompletionDate { get; set; }
        [JsonPropertyName("status")]
        public AssignmentStatus Status { get; set; }
        [JsonPropertyName("notes")]
        public string Notes { get; set; }
        [JsonPropertyName("geologicalSurveys")]
        public List<GeologicalSurvey> GeologicalSurveys { get; set; } = new List<GeologicalSurvey>();
    }
}
