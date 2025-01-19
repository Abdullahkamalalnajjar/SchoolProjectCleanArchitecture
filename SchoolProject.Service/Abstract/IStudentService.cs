using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstract
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIDAsync(int id);
        public Task<string> AddStudentAsync(Student student);
        public Task<string> EditStudentAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
        public Task<string> DeleteStudentAsync(Student student);
        public IQueryable<Student> GetStudentsQueryable();
        public IQueryable<Student> GetStudentsByDepartmentIdQueryable(int DID);
        public IQueryable<Student> FilterStudentsQueryable(StudentOrderingEnum orderingEnum, string search);
    }
}
