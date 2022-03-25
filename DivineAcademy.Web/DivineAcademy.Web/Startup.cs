using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using DivineAcademy.DataBase.Context;
using Microsoft.AspNet.Identity;
using DivineAcademy.Entities.StudentEntities;

[assembly: OwinStartupAttribute(typeof(DivineAcademy.Web.Startup))]
namespace DivineAcademy.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultAdmin();
        }
       
        private void CreateDefaultAdmin()
        {
            DivineDBContext dbContext = new DivineDBContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
            var UserManager = new UserManager<ApplicationUser>(new UserStore< ApplicationUser > (dbContext));
            if(!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";

                string Password = "Admin1234+";
                var adminUser = UserManager.Create(user, Password);
                if(adminUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }



            }
        }
    }
}
