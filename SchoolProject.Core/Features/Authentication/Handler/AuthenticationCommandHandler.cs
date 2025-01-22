using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Authentication.Handler;

public class AuthenticationCommandHandler: ResponseHandler,IRequestHandler<SignInCommand,Response<string>>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public AuthenticationCommandHandler(IAuthenticationService authenticationService,SignInManager<AppUser> signInManager,UserManager<AppUser> userManager,IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _authenticationService = authenticationService;
        _signInManager = signInManager;
        _userManager = userManager;
        _localizer = localizer;
    }

    public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        // checkuser existing or no 
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null) return NotFound<string>();
        // try to signin
        var signinResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);
        if (!signinResult.Succeeded) return BadRequest<string>(_localizer[SharedResourcesKeys.PasswordInCorrect]);
        // Get accessToken
        var accessToken = await _authenticationService.GetTokenAsync(user);
        return Success(accessToken);
    }
    
}