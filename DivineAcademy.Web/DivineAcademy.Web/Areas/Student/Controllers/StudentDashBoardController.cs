using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivineAcademy.Web.Areas.Student.Controllers
{

    [Authorize]
    public class StudentDashBoardController : Controller
    {
        // GET: Student/StudentDashBoard
        public ActionResult Index()
        {
            return View();
        }

       
    }
}