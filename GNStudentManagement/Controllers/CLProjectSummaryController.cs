using GNStudentManagement.BAL;
using GNStudentManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using System.Data;
using System.IO;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLProjectSummaryController : ControllerBase
    {
        BLProjectSummaryHandler objBLProjectSummaryHandler = new BLProjectSummaryHandler();

        #region Get All Project Summaries
        [HttpGet("getall")]
        [Authorize(Policy = "AdminOrStaff")]
        public IActionResult GetAllProjectSummaries()
        {
            Response response = objBLProjectSummaryHandler.GetAll();
            if (!response.IsError)
                return Ok(response);
            else
                return NotFound(response);
        }
        #endregion

        #region Get Project Group Summary by ID
        [HttpGet("id")]
        [Authorize(Policy = "AdminStaffOrStudent")]
        public IActionResult GetProjectMeetingByID([FromQuery] int projectGroupID)
        {
            if (projectGroupID <= 0)
                return BadRequest(new { Message = "Invalid Project Group Summary ID." });

            Response response = objBLProjectSummaryHandler.GetProjectMeetingByID(projectGroupID);
            if (!response.IsError)
                return Ok(response);

            return NotFound(response);
        }
        #endregion

        #region Export All Project Summaries to Excel
        [HttpGet("getallExcel")]
        [Authorize(Policy = "AdminOrStaff")]
        public IActionResult GetAllProjectSummariesExcel()
        {
            Response response = objBLProjectSummaryHandler.GetAllExcel();

            if (response.IsError || response.Data == null)
                return BadRequest(response);

            var dt = (DataTable)response.Data;
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("ProjectSummary");
                ws.Cell(1, 1).InsertTable(dt, "ProjectSummary", true);
                ws.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    stream.Position = 0;
                    string fileName = $"ProjectSummary_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileName);
                }
            }
        }
        #endregion

        #region Export Project Summary by ID to Excel
        [HttpGet("GetByidExcel")]
        [Authorize(Policy = "AdminStaffOrStudent")]
        public IActionResult GetByIDExcel([FromQuery] int projectGroupID)
        {
            if (projectGroupID <= 0)
                return BadRequest(new { Message = "Invalid Project Group Summary ID." });

            Response response = objBLProjectSummaryHandler.GetProjectByIDExcel(projectGroupID);

            if (response.IsError || response.Data == null)
                return BadRequest(response);

            var dt = (DataTable)response.Data;
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("ProjectGroup");
                ws.Cell(1, 1).InsertTable(dt, "ProjectGroup", true);
                ws.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    stream.Position = 0;
                    string fileName = $"ProjectGroup_{projectGroupID}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileName);
                }
            }
        }
        #endregion
    }
}
