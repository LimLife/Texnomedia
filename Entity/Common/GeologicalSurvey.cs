using Entity.Enums;

public class GeologicalSurvey
{
    public Guid Id { get; set; }
    public Guid AssignmentId { get; set; }
    public Assignment Assignment { get; set; }
    public SurveyType SurveyType { get; set; }
    public string Result { get; set; }
    public DateTime SurveyDate { get; set; }
}
