using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DivineAcademy.Service.Services;
using DivineAcademy.Entities.StudentEntities;
using DivineAcademy.Model.ViewModels;
using DivineAcademy.Web.Areas.Student.Controllers;

namespace DivineAcademy.Web.Areas.Admin.Controllers
{
    public class CourseController : ApplicationBaseController
    {
        // GET: Admin/Course
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult SaveCourse()
        {

            CourseNameViewModel model = new  CourseNameViewModel();
            model.AvailableCourseCategories = CourseCategoryService.Instance.GetAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveCourse(CourseNameViewModel model)
        {          

            if (ModelState.IsValid)
            {
                object[] parameters = { model.Name,model.Price,model.Description,model.CourseCategoryID,model.ImageURL };
                CourseNameService.Instance.Insert(parameters);
                TempData["msg"] = "Course Name Inserted Successfully ! Thanks..";
            }
            return RedirectToAction("DisplayCourseCategory");

            //return View();          
        }



        public ActionResult DisplayCourseCategory()
        {
            var result = CourseCategoryService.Instance.GetAll();
            return View(result);
        }
        

        public ActionResult SaveCourseCategory()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourseCategory(CourseCategory model)
        {
            if (ModelState.IsValid)
            {
                object[] parameters = { model.Name, model.Description};
                CourseCategoryService.Instance.Insert(parameters);
                TempData["msg"] = "Category Inserted Successfully ! Thanks..";
            }
            return View();
        }
       
        [HttpGet]
        public ActionResult UpdateCourseCategory(int id)
        {
          
            CourseCategory model = new CourseCategory();
            object[] parameters = { id };
            var result = CourseCategoryService.Instance.GetbyID(parameters);
            model.ID = result.ID;
            model.Name = result.Name;
            model.Description = result.Description;
            return View(model);
        }
      
        [HttpPost]
        public ActionResult UpdateCourseCategory(CourseCategory model)
        {
            object[] parameters = {model.ID, model.Name,model.Description};
            var result = CourseCategoryService.Instance.Update(parameters);
            if (result == 1)
            {
                TempData["msg"] = "Updated Successfully";
                return RedirectToAction("DisplayCourseCategory", "Course");

            }
            else
            {
                TempData["msg"] = "Sorry ! Something Went Wrong...";

            }
            return View();
        }

        public ActionResult DeleteCourseCategory(int id)
        {
            object[] parameters = { id };
            CourseCategoryService.Instance.Delete(parameters);
            TempData["msg"] = "Deleted Successfully";
            return RedirectToAction("DisplayCourseCategory", "Course");
           // return View(result);
        }

    }
}