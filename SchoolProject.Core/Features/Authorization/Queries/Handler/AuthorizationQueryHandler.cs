using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Model;
using SchoolProject.Core.Features.Authorization.Queries.Response;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Authorization.Queries.Handler;

public class AuthorizationQueryHandler:ResponseHandler,IRequestHandler<MangeUserRolesQuery,Response<MangeUserRolesRequest>>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationQueryHandler(UserManager<AppUser> userManager,IAuthorizationService authorizationService,IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _userManager = userManager;
        _authorizationService = authorizationService;
    }


    public async Task<Response<MangeUserRolesRequest>> Handle(MangeUserRolesQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) return NotFound<MangeUserRolesRequest>();
        var roles = await _authorizationService.MangeUserRolesDataAsync(user);
        var response = Success(roles);
        return response;
    }
}