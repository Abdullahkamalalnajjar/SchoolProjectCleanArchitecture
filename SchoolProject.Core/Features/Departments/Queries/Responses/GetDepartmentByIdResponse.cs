namespace SchoolProject.Core.Features.Departments.Queries.Responses;

public class GetDepartmentByIdResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<StudentResponse> Students { get; set; }
    public List<SubjectResponse> Subjects { get; set; }
    public List<InstructorResponse> Instructors { get; set; }
}

public class StudentResponse
{
    public StudentResponse() { } // Parameterless constructor for binding

    public StudentResponse(int id, string name, string address, string phone, string departmentName)
    {
        Id = id;
        Name = name;
        Address = address;
        Phone = phone;
        DepartmentName = departmentName;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string DepartmentName { get; set; }
}

public class SubjectResponse
{
    public SubjectResponse() { } // Parameterless constructor for binding

    public SubjectResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}

public class InstructorResponse
{
    public InstructorResponse() { } // Parameterless constructor for binding

    public InstructorResponse(int id, string? name, decimal? salary, string? position)
    {
        Id = id;
        Name = name;
        Salary = salary;
        Position = position;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal? Salary { get; set; }
    public string? Position { get; set; }
}


