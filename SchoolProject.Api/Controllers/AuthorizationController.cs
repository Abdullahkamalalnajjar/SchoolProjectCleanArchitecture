using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Command.Model;
using SchoolProject.Core.Features.Authorization.Queries.Model;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers;
[Authorize]
public class AuthorizationController : AppBaseController
{
    
    [HttpPost(Router.AuthorizationRouting.CreateRole)]
    public async Task<IActionResult> CreateRoles([FromForm] AddRoleCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
    [HttpGet(Router.AuthorizationRouting.MangeUserRoles)]
    public async Task<IActionResult> MangeUserRoles([FromRoute] string userId )
    {
        var request = new MangeUserRolesQuery(userId);
        var response = await Mediator.Send(request);
        return NewResult(response);
    }
    [HttpPut(Router.AuthorizationRouting.UpdateRole)]
    public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand command )
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
}