using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infrustructure.Abstracts;
using SchoolProject.infrustructure.DbContext;
using SchoolProject.infrustructure.InfrustructureBase;

namespace SchoolProject.infrustructure.Repositories;

public class DepartmentRepository: GenericRepository<Department>, IDepartmentRepository
{
    private DbSet<Department> _departments;
    public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _departments = dbContext.Set<Department>();
    }

}