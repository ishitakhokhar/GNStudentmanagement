using GNStudentManagement.BAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLDashboardController : ControllerBase
    {
        BLDashboardHandler objBLDashboardHandler = new BLDashboardHandler();
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = objBLDashboardHandler.GetAll();
            if (!response.IsError)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }
    }
}
