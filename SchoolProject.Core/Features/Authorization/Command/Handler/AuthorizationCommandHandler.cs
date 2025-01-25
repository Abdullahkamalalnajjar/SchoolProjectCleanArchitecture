using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Command.Model;
using SchoolProject.Core.Features.Authorization.Queries.Response;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Authorization.Command.Handler;

public class AuthorizationCommandHandler:ResponseHandler,
                               IRequestHandler<AddRoleCommand,Response<string>>,
                               IRequestHandler<UpdateUserRolesCommand,Response<string>>
{
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationCommandHandler(IAuthorizationService authorizationService,IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _authorizationService = authorizationService;
    }

    public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _authorizationService.AddRoleAsync(request.RoleName);
        return result=="Added" ? Created("") : BadRequest<string>();
    }

    public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
    {
        var req = new MangeUserRolesRequest();
        req.UserId = request.UserId;
        req.UserRoles=request.Roles;
        var result = await _authorizationService.UpdateUserRolesAsync(req);
        switch (result)
        {
            case "FailedToRemoveRoles": return BadRequest<string>("Failed to remove roles");
            case "FailedToAddRoles": return BadRequest<string>("Failed to add roles");
            default: return Updated<string>("Successfully updated roles");
        }
    }
}