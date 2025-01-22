using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Model;
using SchoolProject.Core.Features.Students.Queries.Model;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class StudentsController : AppBaseController
    {


        //GET StudentList
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentsList()
        {

            var request = new GetStudentListQuery();
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        //GET SingleStudent
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentByID([FromRoute] int id)
        {
            var request = new GetSingleStudentQuery(id);
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
        //GET PaginatedStudent
        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> GetStudentPaginated([FromQuery] GetStudentPaginatedListQuery query)
        {

            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [Authorize]
        //POST CreateStudent
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        //PUT EditStudent
        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        //Delete DeleteStudent
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var request = new DeleteStudentCommand(id);
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
