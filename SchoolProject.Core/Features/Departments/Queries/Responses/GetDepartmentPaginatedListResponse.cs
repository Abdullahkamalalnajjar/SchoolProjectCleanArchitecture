namespace SchoolProject.Core.Features.Departments.Queries.Responses;

public class GetDepartmentPaginatedListResponse
{
    public GetDepartmentPaginatedListResponse(int id, string name, List<StudentResponse> students, List<SubjectResponse> subjects, List<InstructorResponse> instructors)
    {
        Id = id;
        Name = name;
        Students = students;
        Subjects = subjects;
        Instructors = instructors;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public List<StudentResponse> Students { get; set; }
    public List<SubjectResponse> Subjects { get; set; }
    public List<InstructorResponse> Instructors { get; set; }

}
