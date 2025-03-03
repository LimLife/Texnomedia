using Application.Entity;

namespace WEB.Tools
{
    public class MapTeamConvert
    {
        public static TeamDTO ToTeamDTO(Team team)
        {
            if (team != null)
            {
                return new TeamDTO
                {
                    Id = team.Id,
                    Name = team.Name,
                    TypeBrigade = team.TypeBrigade,

                };
            }
            return null;
        }
        public static Team ToTeam(TeamDTO team)
        {
            if (team != null)
            {
                return new Team()
                {
                    Id = team.Id,
                    Name = team.Name,
                    TypeBrigade = team.TypeBrigade
                };
            }
            return null;
        }
        public static List<TeamDTO> ToTeamDTOList(List<Team> teams)
        {
            if (teams != null)
            {
                return teams.Select(team => ToTeamDTO(team)).ToList();
            }
            return null;
        }

        public static List<Team> ToTeamList(List<TeamDTO> teamDTO)
        {
            if (teamDTO != null)
            {
                return teamDTO.Select(teamDto => ToTeam(teamDto)).ToList();
            }
            return null;
        }
    }

}
