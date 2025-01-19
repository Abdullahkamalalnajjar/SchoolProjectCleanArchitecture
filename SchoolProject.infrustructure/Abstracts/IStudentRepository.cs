using SchoolProject.Data.Entities;
using SchoolProject.infrustructure.InfrustructureBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infrustructure.Abstracts
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        public Task<List<Student>> GetStudentsListAsync();
    }
}
