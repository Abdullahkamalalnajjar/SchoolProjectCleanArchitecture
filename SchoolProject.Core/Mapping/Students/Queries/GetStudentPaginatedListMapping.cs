using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentPaginationMapping()
        {
            CreateMap<Student, GetStudentPaginatedListResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
        }
    }
}