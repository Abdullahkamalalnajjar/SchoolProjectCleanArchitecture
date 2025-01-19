using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectsId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subjects Subject { get; set; }
    }
}
