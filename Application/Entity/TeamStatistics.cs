using System.Text.Json.Serialization;

namespace Application.Entity
{
    public class TeamStatistics
    {
        [JsonPropertyName("teamName")]
        public string TeamName { get; set; }
        [JsonPropertyName("completedAssignments")]
        public int CompletedAssignments { get; set; }
        [JsonPropertyName("totalTimeSpent")]
        public double TotalHoursSpent { get; set; }
    }

}