using Entity.Enums;

public class Assignment
{
    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Request Request { get; set; }
    public string Description { get; set; }
    public int TeamId { get; set; }
    public Team Team { get; set; }
    public DateTime AssignmentDate { get; set; }
    public DateTime CompletionDate { get; set; } 
    public AssignmentStatus Status { get; set; }
    public string Notes { get; set; }
    public List<GeologicalSurvey> GeologicalSurveys { get; set; } = new List<GeologicalSurvey>();
}