using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infrustructure.Abstracts;
using SchoolProject.infrustructure.DbContext;
using SchoolProject.infrustructure.InfrustructureBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolProject.infrustructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly DbSet<Student> _studentsRepository;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _studentsRepository = context.Set<Student>();
        }

     
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentsRepository.Include(d => d.Department).ToListAsync();
        }
    }
}
