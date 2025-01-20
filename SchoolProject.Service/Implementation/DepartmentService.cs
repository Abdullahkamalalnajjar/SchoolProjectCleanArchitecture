using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.infrustructure.Abstracts;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Service.Implementation;

public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository = departmentRepository;

    public async Task<Department?> GetDepartmentByIdAsync(int departmentId)
    {
        return await departmentRepository.GetTableNoTracking()
            .Include(s => s.Students)
            .Include(ds => ds.DepartmentSubjects)
            .Include(i => i.Instructors)
            .FirstOrDefaultAsync(x => x.Id == departmentId);
    }

    public IQueryable<Department> GetDepartmentQueryable()
    {
        return departmentRepository.GetTableNoTracking()
            .Include(s => s.Students)
            .Include(ds => ds.DepartmentSubjects)
            .Include(i => i.Instructors)
            .AsQueryable();
    }
    public IQueryable<Department> FilterWithPaginationDepartmentQueryable(string? search, DepartmentOrderingEnum? departmentOrderingEnum)
    {
        var queryable = departmentRepository.GetTableNoTracking()
            .Include(s => s.Students)
            .Include(ds => ds.DepartmentSubjects)
            .Include(i => i.Instructors)
            .AsQueryable();
        if (!string.IsNullOrEmpty(search))
        {
            queryable = queryable.Where(n => n.Name.Contains(search)).AsQueryable();
        }

        switch (departmentOrderingEnum)
        {
            case DepartmentOrderingEnum.Name:
                queryable = queryable.OrderBy(n => n.Name);
                break;
            case DepartmentOrderingEnum.Id:
                queryable = queryable.OrderBy(n => n.Id);
                break;

            default:
                queryable = queryable.OrderBy(n => n.Id);
                break;
        }
        return queryable;
    }

    public async Task<string> AddDepartmentAsync(Department department)
    {
        var departmentResult = await _departmentRepository.GetTableNoTracking().FirstOrDefaultAsync(d => d.Name == department.Name);
        if (departmentResult is not null) return "Existing";
        await _departmentRepository.AddAsync(department);
        return "Added";
    }

    public async Task<bool> IsNameExist(string name)
    {
        var result = await _departmentRepository
            .GetTableNoTracking().FirstOrDefaultAsync(n => n.Name == name);
        if (result is not null) return true;
        return false;
    }

    public async Task<string> DeleteDepartmentAsync(Department department)
    {
        await _departmentRepository.DeleteAsync(department);
        return "Deleted";

    }

    public async Task<string> EditDepartmentAsync(Department department)
    {
        await _departmentRepository.UpdateAsync(department);
        return "Updated";
    }

    public async Task<bool> IsNameExistExcludeSelf(int id, string name)
    {
        var result = await _departmentRepository.GetTableNoTracking()
            .Where(n => n.Name.Equals(name) & !n.Id.Equals(id)).FirstOrDefaultAsync();
        if (result is not null) return true; return false;
    }

    public async Task<List<Department>> GetDepartmentListAsync()
    {
        var departmentList = await _departmentRepository.GetTableNoTracking()
            .Include(s => s.Students)
            .Include(i => i.Instructors)
            .Include(i => i.DepartmentSubjects).ToListAsync();
        return departmentList;
    }

    public async Task<bool> IsDepartmentExist(int? departmentId) => await _departmentRepository.GetTableNoTracking().AnyAsync(d => d.Id == departmentId);


}