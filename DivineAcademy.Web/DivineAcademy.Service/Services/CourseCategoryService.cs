using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivineAcademy.Repository.GenericRepository;
using DivineAcademy.Entities.StudentEntities;
using DivineAcademy.DataBase.Context;
using System.Data.Entity;

namespace DivineAcademy.Service.Services
{
    public partial class CourseCategoryService {


        public static CourseCategoryService Instance
        {
            get
            {
                if (instance == null) instance = new CourseCategoryService();
                return instance;
            }
        }

        private static CourseCategoryService instance { get; set; }

        private GenericRepository<CourseCategory> courseCategory;       

        public CourseCategoryService()
        {
            this.courseCategory = new GenericRepository<CourseCategory>(new DivineDBContext());
            
        }

        public int Insert(object[] parameters)
        {
            string spquery = "[sp_SaveCourseCategory] {0},{1}";
            return courseCategory.ExecuteCommand(spquery,parameters);
        }
        
        public IEnumerable<CourseCategory> GetAll()
        {
            string spQuery = "[sp_DisplayCourseCategory]";
            return courseCategory.ExecuteQuery(spQuery);
        }
        public CourseCategory GetbyID(object[] parameters)
        {
            string spQuery = "[sp_DisplayCourseCategoryById] {0}";
            return courseCategory.ExecuteQuerySingle(spQuery, parameters);
        }
        public int Update(object[] parameters)
        {
            string spQuery = "[sp_UpdateCourseCategory] {0},{1},{2}";
            return courseCategory.ExecuteCommand(spQuery, parameters);
        }
        public int Delete(object[] parameters)
        {
            string spQuery = "[sp_DeleteCourseCategory] {0}";
            return courseCategory.ExecuteCommand(spQuery, parameters);
        }

        
    }
}
