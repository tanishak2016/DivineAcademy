using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DivineAcademy.Entities;
using DivineAcademy.DataBase.Context;
using Microsoft.AspNet.Identity;


namespace DivineAcademy.Web.Areas.Student.Controllers
{
    public class ApplicationBaseController : Controller
    {  
       
        
        // GET: Student/ApplicationBase
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new DivineDBContext();
                var userid = User.Identity.GetUserId();
                var username = User.Identity.Name;
                

                if (!string.IsNullOrEmpty(username))
                {
                    String fullName, address, email, phoneno, gender, UserNames,userID;
                    var user = context.Users.SingleOrDefault(u => u.UserName == username || u.Id==userid);
                    //fullName = string.Concat(new string[] { user.FullName });

                    if (user != null)
                    {
                        userID = user.Id;
                        fullName = user.FullName;
                        address = user.Address;
                        email = user.Email;
                        phoneno = user.PhoneNumber;
                        gender = user.Gender;
                        UserNames = user.UserName;

                        ViewData.Add("userID", userID);
                        ViewData.Add("FullName", fullName);
                        ViewData.Add("Address", address);
                        ViewData.Add("Email", email);
                        ViewData.Add("PhoneNo", phoneno);
                        ViewData.Add("Gender", gender);
                        ViewData.Add("UserName", UserNames);
                    }
                    else{

                    }
                    



                }
            }
            base.OnActionExecuted(filterContext);
        }
        public ApplicationBaseController()
        { }
    }
}