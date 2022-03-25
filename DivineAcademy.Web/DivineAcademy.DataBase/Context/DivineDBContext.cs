using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DivineAcademy.Entities.StudentEntities;

namespace DivineAcademy.DataBase.Context
{
  public  class DivineDBContext: IdentityDbContext<ApplicationUser>
    {
        public DivineDBContext():base("myconnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public static DivineDBContext Create()
        {
            return new DivineDBContext();
      }

        public DbSet<CourseName> CourseNames { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }

    }
}
