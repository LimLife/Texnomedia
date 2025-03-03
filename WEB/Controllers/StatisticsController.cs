using Application.Entity;
using Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsService;

        public StatisticsController(IStatisticsRepository statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet()]
        [Route("statistic")]
        public async Task<List<TeamStatistics>> GetMonthlyStatistics([FromQuery] string start, [FromQuery] string end)
        {
            if (!DateTime.TryParse(start, out var startDate))
            {
                throw new ArgumentException("Некорректный формат даты начала периода.");
            }
            if (!DateTime.TryParse(end, out var endDate))
            {
                throw new ArgumentException("Некорректный формат даты окончания периода.");
            }
            if (startDate > endDate)
            {
                throw new ArgumentException("Дата начала периода не может быть позже даты окончания.");
            }
            try
            {
                return await _statisticsService.GetMonthlyStatisticsAsync(startDate, endDate) ?? [];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
