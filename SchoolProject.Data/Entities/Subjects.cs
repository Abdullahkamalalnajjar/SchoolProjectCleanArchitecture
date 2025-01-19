using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class Subjects
    {
        public Subjects()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmetSubject>();
        }
        [Key]
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int Period { get; set; }
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
        public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; }
    }
}
