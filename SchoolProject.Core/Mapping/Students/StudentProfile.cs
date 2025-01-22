using AutoMapper;

namespace SchoolProject.Core.Features.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {

            GetStudentListMapping();
            GetSingleStudentMapping();
            GetStudentPaginationMapping();
            AddStudentMapping();
            EditStudentMapping();
            
        }

    }
}
