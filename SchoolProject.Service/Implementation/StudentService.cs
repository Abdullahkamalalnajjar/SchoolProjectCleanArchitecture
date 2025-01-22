using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.infrustructure.Abstracts;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Service.Implementation
{
    public class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        private readonly IStudentRepository _studentRepository = studentRepository;

        public async Task<string> AddStudentAsync(Student student)
        {
            var studentResult = await _studentRepository
                                      .GetTableNoTracking()
                                      .FirstOrDefaultAsync(s => s.Name.Equals(student.Name));
            if (studentResult != null) return "Exist";

            await _studentRepository.AddAsync(student);
            return "Created";
        }

        public async Task<string> DeleteStudentAsync(Student student)
        {
            await _studentRepository.DeleteAsync(student);
            return "Deleted";
        }

        public IQueryable<Student> GetStudentsQueryable()
        {
            return _studentRepository.GetTableNoTracking()
                .Include(d => d.Department).AsQueryable();
        }

        public async Task<string> EditStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Updated";
        }

        public async Task<Student> GetStudentByIDAsync(int id)
        {
            var student = await _studentRepository.GetTableNoTracking()
                                                  .Include(d => d.Department)
                                                  .FirstOrDefaultAsync(s => s.Id.Equals(id));
            return student;
        }
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }

        public async Task<bool> IsNameExist(string name)
        {

            var result = await _studentRepository.GetTableNoTracking().FirstOrDefaultAsync(s => s.Name.Equals(name));
            if (result != null) return true;
            return false;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var result = await _studentRepository.GetTableNoTracking().FirstOrDefaultAsync(s => s.Name.Equals(name) & !s.Id.Equals(id));
            if (result != null) return true;
            return false;
        }

        public IQueryable<Student> GetStudentsByDepartmentIdQueryable(int DID)
        {
            return _studentRepository.GetTableNoTracking().Where(d => d.DepartmentId == DID).AsQueryable();
        }

       
        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search)
        {
            var querable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search!=null)
            {
                querable = querable.Where(x => x.Name.Contains(search)||x.Address.Contains(search));
            }
            switch (orderingEnum)
            {
                case StudentOrderingEnum.StudentId:
                    querable=querable.OrderBy(x => x.Id);
                    break;
                case StudentOrderingEnum.Name:
                    querable=querable.OrderBy(x => x.Name);
                    break;
                case StudentOrderingEnum.Address:
                    querable=querable.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    querable=querable.OrderBy(x => x.Department.Name);
                    break;
            }

            return querable;
        }
    }
}
