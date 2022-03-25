using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineAcademy.Entities.StudentEntities
{
   public class CourseCategory:BaseEntity
    {
        public List<CourseName> CourseNames { get; set; }
    }
}
