using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.infrustructure.Abstracts;
using SchoolProject.infrustructure.DbContext;
using SchoolProject.infrustructure.InfrustructureBase;

namespace SchoolProject.infrustructure.Repositories;

public class UserRefreshTokenRepository:GenericRepository<UserRefreshToken>,IUserRefreshTokenRepository
{
    #region Fields
    private DbSet<UserRefreshToken> userRefreshToken;
    #endregion
    public UserRefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        userRefreshToken=dbContext.Set<UserRefreshToken>();
    }
}