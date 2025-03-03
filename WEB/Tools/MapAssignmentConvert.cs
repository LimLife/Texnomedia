using Application.Entity;

namespace WEB.Tools
{
    public class MapAssignmentConvert
    {
        public static AssignmentDTO ToAssignmentDTO(Assignment assignment)
        {
            if (assignment != null)
            {
                return new AssignmentDTO
                {
                    Id = assignment.Id,
                    Status = assignment.Status,
                    Description = assignment.Description,
                    AssignmentDate = assignment.AssignmentDate,
                    CompletionDate = assignment.CompletionDate,
                    GeologicalSurveys = assignment.GeologicalSurveys,
                    Notes = assignment.Notes
                };
            }
            return null;
        }
        public static Assignment ToAssignment(AssignmentDTO assignment)
        {
            if (assignment != null)
            {
                return new Assignment()
                {
                    Id = assignment.Id,
                    Status = assignment.Status,
                    Description = assignment.Description,
                    AssignmentDate = assignment.AssignmentDate,
                    CompletionDate = assignment.CompletionDate,
                    Notes = assignment.Notes = assignment.Notes,
                    GeologicalSurveys = assignment.GeologicalSurveys,
                };
            }
            return null;
        }
        public static List<AssignmentDTO> ToAssignmentDTOList(List<Assignment> assignment)
        {
            if (assignment != null)
            {
                return assignment.Select(assignment => ToAssignmentDTO(assignment)).ToList();
            }
            return null;
        }

        public static List<Assignment> ToAssignmentList(List<AssignmentDTO> assignmentDTO)
        {
            if (assignmentDTO != null)
            {
                return assignmentDTO.Select(assignmentDTO => ToAssignment(assignmentDTO)).ToList();
            }
            return null;
        }
    }
}
