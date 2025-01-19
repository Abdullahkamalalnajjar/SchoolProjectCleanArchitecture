namespace SchoolProject.Data.Entities
{
    public class SubjectInstractor
    {
        public int Id { get; set; }
        public int InstractorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public int SubjectsId { get; set; }
        public virtual Subjects Subject { get; set; }
    }
}
