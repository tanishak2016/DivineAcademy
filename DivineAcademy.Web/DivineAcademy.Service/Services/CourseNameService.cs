using DivineAcademy.DataBase.Context;
using DivineAcademy.Entities.StudentEntities;
using DivineAcademy.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineAcademy.Service.Services
{
  public  class CourseNameService {

        public static CourseNameService Instance
        {
            get
            {
                if (instance == null) instance = new CourseNameService();
                return instance;
            }
        }

        private static CourseNameService instance { get; set; }

        private GenericRepository<CourseName> courseName;

        public CourseNameService()
        {
            this.courseName = new GenericRepository<CourseName>(new DivineDBContext());

        }

        public int Insert(object[] parameters)
        {
            string spquery = "[sp_SaveCourseName] {0},{1},{2},{3},{4}";
            return courseName.ExecuteCommand(spquery, parameters);
        }

        public IEnumerable<CourseName> GetAll()
        {
            string spQuery = "[sp_DisplayCourseCategory]";
            return courseName.ExecuteQuery(spQuery);
        }
        public CourseName GetbyID(object[] parameters)
        {
            string spQuery = "[sp_DisplayCourseCategoryById] {0}";
            return courseName.ExecuteQuerySingle(spQuery, parameters);
        }
        public int Update(object[] parameters)
        {
            string spQuery = "[sp_UpdateCourseCategory] {0},{1},{2}";
            return courseName.ExecuteCommand(spQuery, parameters);
        }
        public int Delete(object[] parameters)
        {
            string spQuery = "[sp_DeleteCourseCategory] {0}";
            return courseName.ExecuteCommand(spQuery, parameters);
        }



    }
}
