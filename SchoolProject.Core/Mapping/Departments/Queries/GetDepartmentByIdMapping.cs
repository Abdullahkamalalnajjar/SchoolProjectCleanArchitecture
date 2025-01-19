using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Departments;

public partial class DepartmentProfile
{
    public void MappingGetDepartmentByIdMapping()
    {
        CreateMap<Department, GetDepartmentByIdResponse>()
            .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.DepartmentSubjects))
            .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
            .ForMember(dest => dest.Instructors, opt => opt.MapFrom(src => src.Instructors));

        CreateMap<Student, StudentResponse>()
          .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));

        CreateMap<DepartmetSubject, SubjectResponse>()
          .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subjects.SubjectName))
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Subjects.Id));

    }

}