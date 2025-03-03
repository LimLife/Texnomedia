using Application.Entity;
using Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using WEB.Tools;

namespace WEB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentService;

        public AssignmentsController(IAssignmentRepository assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpPost]
        [Route("createAssignment")]
        public async Task<Assignment> AssignOrderToBrigade([FromBody] AssignmentDTO assignment)
        {
            try
            {
                var assignmentEntity = MapAssignmentConvert.ToAssignment(assignment);
                return await _assignmentService.AssignOrderToBrigadeAsync(assignmentEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("assignments")]
        public async Task<List<AssignmentDTO>> GetAllAssignments()
        {
            try
            {
               var assignments = await _assignmentService.GetAllAssignmentsAsync();
                return MapAssignmentConvert.ToAssignmentDTOList(assignments);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
