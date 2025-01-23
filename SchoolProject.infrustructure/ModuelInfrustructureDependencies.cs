using Microsoft.Extensions.DependencyInjection;
using SchoolProject.infrustructure.Abstracts;
using SchoolProject.infrustructure.InfrustructureBase;
using SchoolProject.infrustructure.Repositories;

namespace SchoolProject.infrustructure
{
    public static class ModuelInfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
        {

            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
