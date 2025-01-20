using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Command.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.Users.Command.Handler;

public class AppUserHandler:ResponseHandler , IRequestHandler<AddUserCommand,Response<string>>
{
    private readonly IStringLocalizer<SharedResources> _localizer;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public AppUserHandler(IStringLocalizer<SharedResources> localizer ,IMapper mapper, UserManager<AppUser> userManager) : base(localizer)
    {
        _localizer = localizer;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        // check email exist or no
        var checkEmailUser = await _userManager.FindByEmailAsync(request.Email);
        if (checkEmailUser != null) return BadRequest<string>(_localizer[SharedResourcesKeys.Email]+":"+_localizer[SharedResourcesKeys.IsExist]);
        // check username exist or no
        var checkUsername = await _userManager.FindByNameAsync(request.Username);
        if (checkUsername != null) return BadRequest<string>(_localizer[SharedResourcesKeys.UserName]+":"+_localizer[SharedResourcesKeys.IsExist]);
        // Make Mapping
        var user = _mapper.Map<AppUser>(request);   
        // Create user
       var result = await _userManager.CreateAsync(user, request.Password);
       if (!result.Succeeded)
       {
           // Localize each error and return the first one
           var localizedErrors = result.Errors
               .Select(error => _localizer[$"{error.Code}"] ?? error.Description)
               .ToList();
        //   return BadRequest<string>(localizedErrors.FirstOrDefault()!);
           return BadRequest<string>(localizedErrors.FirstOrDefault()!);
 
       }
       return Created(_localizer[SharedResourcesKeys.SignUpSuccess].Value);
    }
}
