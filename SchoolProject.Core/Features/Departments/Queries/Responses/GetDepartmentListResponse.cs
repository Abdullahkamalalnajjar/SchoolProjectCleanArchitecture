namespace SchoolProject.Core.Features.Departments.Queries.Responses
{
    public class GetDepartmentListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentResponse> Students { get; set; }
        public List<SubjectResponse> Subjects { get; set; }
        public List<InstructorResponse> Instructors { get; set; }
    }
}
