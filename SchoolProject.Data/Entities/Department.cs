using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class Department
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }= new List<Student>();    
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }=new List<DepartmetSubject>();
        public virtual ICollection<Instructor> Instructors { get; set; }

    }
}
