using SchoolProject.Core.Features.Students.Commands.Model;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentMapping()
        {




            CreateMap<EditStudentCommand, Student>()
           .ForAllMembers(opt =>
               opt.Condition((src, dest, srcMember) =>
                   srcMember != null &&
                   !(srcMember is string str && string.IsNullOrEmpty(str)))); // تجاهل الحقول null أو الفارغة

        }
    }
}
