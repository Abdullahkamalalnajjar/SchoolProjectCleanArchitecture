using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstract;

public interface IDepartmentService
{
    public Task<Department?> GetDepartmentByIdAsync(int departmentId);
    public Task<List<Department>> GetDepartmentListAsync();
    public Task<string> AddDepartmentAsync(Department department);
    public Task<string> EditDepartmentAsync(Department department);
    public Task<string> DeleteDepartmentAsync(Department department);
    public Task<bool> IsNameExist(string name);
    public Task<bool> IsDepartmentExist(int? departmentId);
    public Task<bool> IsNameExistExcludeSelf(int id, string name);
    public IQueryable<Department> GetDepartmentQueryable();
    public IQueryable<Department> FilterWithPaginationDepartmentQueryable(string? search, DepartmentOrderingEnum? departmentOrderingEnum);
}