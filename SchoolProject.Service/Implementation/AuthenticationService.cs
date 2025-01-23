using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.infrustructure.Abstracts;
using SchoolProject.Service.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Service.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRefreshTokenRepository _refreshTokenRepository;
    private readonly JwtSettings _jwtSettings;

    public AuthenticationService(IUserRefreshTokenRepository userRefreshTokenRepository, JwtSettings jwtSettings)
    {
        _refreshTokenRepository = userRefreshTokenRepository;
        _jwtSettings = jwtSettings;
    }

    public async Task<JwtAuthResult> GetTokenAsync(AppUser user)
    {
        var claims = GetClaims(user);
        var jwtToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpireDate),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256)
        );
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        var refreshToken = GetRefreshToken(user.UserName);

        var userRefreshToken = new UserRefreshToken
        {
            AddedTime = DateTime.Now,
            ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
            IsUsed = true,
            IsRevoked = false,
            JwtId = jwtToken.Id,
            RefreshToken = refreshToken.TokenString,
            Token = accessToken,
            AppUserId = user.Id
        };
        await _refreshTokenRepository.AddAsync(userRefreshToken);

        var response = new JwtAuthResult
        {
            AccessToken = accessToken,
            refreshToken = refreshToken,
        };
        return response;
    }
    private JwtAuthResult.RefreshToken GetRefreshToken(string username)
    {
        var refreshToken = new JwtAuthResult.RefreshToken
        {
            ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
            UserName = username,
            TokenString = GenerateRefreshToken()
        };
        return refreshToken;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        var randomNumberGenerate = RandomNumberGenerator.Create();
        randomNumberGenerate.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private List<Claim> GetClaims(AppUser user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),
            new Claim(nameof(UserClaimModel.Id), user.Id)
        };
        return claims;
    }
}