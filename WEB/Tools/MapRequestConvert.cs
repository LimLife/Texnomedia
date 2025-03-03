using Application.Entity;

namespace WEB.Tools
{
    public class MapRequestConvert
    {
        public static RequestDTO ToRequestDTO(Request request)
        {
            if (request != null)
            {
                return new RequestDTO
                {
                    Id = request.Id,
                    Assignments = request.Assignments,
                    CreationDate = request.CreationDate,
                    Description = request.Description,
                    Status = request.Status
                };
            }
            return null;
        }
        public static Request ToRequest(RequestDTO request)
        {
            if (request != null)
            {
                return new Request()
                {
                    Id = request.Id,
                    Assignments = request.Assignments,
                    CreationDate = request.CreationDate,
                    Description = request.Description,
                    Status = request.Status
                };
            }
            return null;
        }

        public static List<RequestDTO> ToRequestDTOList(List<Request> teams)
        {
            if (teams != null)
            {
                return teams.Select(request => ToRequestDTO(request)).ToList();
            }
            return null;
        }

        public static List<Request> ToTeamList(List<RequestDTO> teamDTO)
        {
            if (teamDTO != null)
            {
                return teamDTO.Select(teamsDTO => ToRequest(teamsDTO)).ToList();
            }
            return null;
        }
    }
}
