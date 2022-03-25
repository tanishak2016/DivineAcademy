using DivineAcademy.DataBase.Context;
using DivineAcademy.Entities.StudentEntities;
using DivineAcademy.Helper.EmailHelper;
using DivineAcademy.Web.Areas.Student.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DivineAcademy.Helper.Utilities;


namespace DivineAcademy.Web.Areas.Student.Controllers
{

    [Authorize]
    public class StudentDashBoardController : ApplicationBaseController
    {

        UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DivineDBContext()));


        public StudentDashBoardController()
        {

        }       

      //  GET: Student/StudentDashBoard
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {


           // var store = new UserStore<ApplicationUser>(new DivineDBContext());
           // var manager = new UserManager<ApplicationUser>(store);
           //var result= manager.FindById(id);
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DivineDBContext()));

            var user = UserManager.FindById(id);
            if(user==null)
            {
                ViewBag.ErrorMessage = $"User with id={id} can not be found";
                return View("NotFound");
            }
            var model = new EditUserViewModel
            {
                ID = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                Address = user.Address,
                UserName = user.UserName

            };

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> EditUser(EditUserViewModel model)
        {

            //UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DivineDBContext()));
            var user =  UserManager.FindById(model.ID);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id={model.ID} can not be found";
                return View("NotFound");
            }
            else
            {
                user.FullName = model.FullName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Gender = model.Gender;              
                user.Address = model.Address;
                user.UserName = model.UserName;
                var result = await UserManager.UpdateAsync(user);    
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                AddErrors(result);
                return View(model);

            }

          //  return View();
        }

        public ActionResult PageNotFound()
        {

            return View();
        }


        public ActionResult ResetPassword(string code,string email)
        {           
            if(code==null || email==null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return  View();
        }
      
        [HttpPost]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await UserManager.FindByIdAsync(model.ID);
            // var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("DivineAcademy.Web");

            var provider = new MachineKeyProtectionProvider();

            UserManager.UserTokenProvider = new Microsoft.AspNet.Identity.Owin.DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));
            model.Code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            if(user==null)
            {
                return RedirectToAction("ResetPasswordConfirmation", "StudentDashBoard");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id,model.Code,model.Password);
            if(result.Succeeded)
            {
                String body = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("~/MailTemplate/ResetPassword.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", model.Email);
                body = body.Replace("{Password}", model.Password);
                bool IsSendEmail = SendMail.EmailSend(model.Email, "You Have Reset Your Password", body, true);
                if (IsSendEmail)
                {
                    TempData["msg"] = user.FullName.ToUpper() + ":" + "You Have Reset Password Successfully. We Have Sent New Password On Your Registered Email. Keep This Password Safe For Future";
                }
            }
            AddErrors(result);
            return View();

        }
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}