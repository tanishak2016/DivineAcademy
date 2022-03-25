using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineAcademy.Entities.StudentEntities
{
 public class CourseName:BaseEntity {


        [Range(1, 100000)]
        public decimal Price { get; set; }

        public int CourseCategoryID { get; set; }
        public virtual CourseCategory CourseCategory { get; set; }

        public String ImageURL { get; set; }

    }
}
