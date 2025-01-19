namespace SchoolProject.Data.Entities;

public class Instructor
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Position { get; set; }
    public decimal? Salary { get; set; }
    public string? Image { get; set; }
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
}