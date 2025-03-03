using Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Application.Entity;
using WEB.Tools;

namespace WEB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _reportService;

        public RequestController(IRequestRepository reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        [Route("createRequest")]
        public async Task<Request> CreateReport([FromBody] RequestDTO request)
        {
            try
            {

                var reportEntity = MapRequestConvert.ToRequest(request);
                return  await _reportService.CreateReportAsync(reportEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("requests")]
        public async Task<List<RequestDTO>> GetAllReports()
        {
            try
            {
                var request = await _reportService.GetAllReportsAsync() ?? [];
                return MapRequestConvert.ToRequestDTOList(request);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
