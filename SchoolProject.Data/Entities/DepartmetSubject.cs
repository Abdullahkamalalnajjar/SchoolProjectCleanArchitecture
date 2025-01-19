using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class DepartmetSubject
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int SubjectsId { get; set; }
        public virtual Department Department { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
