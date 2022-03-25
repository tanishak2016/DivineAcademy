using DivineAcademy.Entities.StudentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineAcademy.Model.ViewModels
{
  public  class CourseNameViewModel {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CourseCategoryID { get; set; }
        public string ImageURL { get; set; }

        public IEnumerable<CourseCategory> AvailableCourseCategories { get; set; }
    }
}
