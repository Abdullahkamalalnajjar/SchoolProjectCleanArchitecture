using SchoolProject.Core.Features.Departments.Commands.Model;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Departments;

public partial class DepartmentProfile
{
    public void AddEditDepartmentMapping()
    {
        CreateMap<EditDepartmentCommand, Department>();
    }

}

