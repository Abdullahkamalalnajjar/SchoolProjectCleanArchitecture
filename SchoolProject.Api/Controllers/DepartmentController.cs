using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Departments.Commands.Model;
using SchoolProject.Core.Features.Departments.Queries;
using SchoolProject.Core.Features.Departments.Queries.Model;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{

    [ApiController]
    public class DepartmentController : AppBaseController
    {


        //GET SingleDepartment
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetStudentByID([FromRoute] int id)
        {
            var request = new GetDepartmentByIdQuery(id);
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        //GET DepartmentList
        [HttpGet(Router.DepartmentRouting.List)]
        public async Task<IActionResult> GetDepartmentList()
        {

            var request = new GetDepartmentListQuery();
            var response = await Mediator.Send(request);
            return Ok(response);
        }
        //GET Pagination
        [HttpGet(Router.DepartmentRouting.Paginated)]
        public async Task<IActionResult> GetDepartmentPaginated([FromQuery] GetDepartmentPaginatedListQuery query)
        {

            var response = await Mediator.Send(query);
            return Ok(response);
        }

        //POST Add Department
        [HttpPost(Router.DepartmentRouting.Create)]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        //Delete Delete Department
        [HttpDelete(Router.DepartmentRouting.Delete)]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            var request = new DeleteDepartmentCommand(id);
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        //PUT EditDepartment
        [HttpPut(Router.DepartmentRouting.Edit)]
        public async Task<IActionResult> EditDepartment([FromBody] EditDepartmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
