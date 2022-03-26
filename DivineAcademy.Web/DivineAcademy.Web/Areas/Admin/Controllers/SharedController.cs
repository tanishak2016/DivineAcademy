using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivineAcademy.Web.Areas.Admin.Controllers
{
    public class SharedController : Controller
    {
        // GET: Admin/Shared
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];
                var fileName = Guid.NewGuid()+Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/content/course-img"), fileName);
                file.SaveAs(path);
                result.Data = new { Sucess = true, ImageURL = string.Format("/content/course-img/{0}",fileName)};
            }
            catch(Exception ex)
            {
                result.Data =new { success=false,Message=ex.Message};
            }
            return result;
        }
    }
}