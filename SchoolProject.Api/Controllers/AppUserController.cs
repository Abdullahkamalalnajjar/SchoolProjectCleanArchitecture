using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Users.Command.Model;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers;

public class AppUserController : AppBaseController
{
   
    //POST Create User
    [HttpPost(Router.UserRouting.Create)]
    public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
}