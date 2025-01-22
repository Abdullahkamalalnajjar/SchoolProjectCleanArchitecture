using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authentication.Model;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers;

public class AuthenticationController : AppBaseController
{

    [HttpPost(Router.AuthenticationRouting.SginIn)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }

}