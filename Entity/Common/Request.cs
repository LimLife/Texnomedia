using Entity.Enums;

public class Request
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public RequestStatus Status { get; set; }
    public List<Assignment> Assignments { get; set; } = new List<Assignment>();
}
