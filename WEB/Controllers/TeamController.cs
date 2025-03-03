using Application.Entity;
using Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using WEB.Tools;

namespace WEB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _orderService;

        public TeamController(ITeamRepository orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("createTeam")]
        public async Task<Team> CreateOrderAsync([FromBody] TeamDTO team)
        {
            try
            {
                var teamEntiti = MapTeamConvert.ToTeam(team);
                return await _orderService.CreateOrderAsync(teamEntiti);              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("teams")]
        public async Task<List<TeamDTO>> GetAllOrdersAsync()
        {
            try
            {
               var teams = await _orderService.GetAllOrdersAsync() ?? [];
               return MapTeamConvert.ToTeamDTOList(teams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
