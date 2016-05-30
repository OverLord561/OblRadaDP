using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Oleg.Models;
using WebMatrix.WebData;

namespace Oleg.Controllers
{
    public class HomeController : Controller
    {
        private UsersContext userprofile = new UsersContext();
        public ActionResult Index()
        {
            ViewBag.Message = "Измените этот шаблон, чтобы быстро приступить к работе над приложением ASP.NET MVC.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница описания приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";

            return View();
        }

        [Authorize(Roles = "Admin")] // К данному методу действия могут получать доступ только пользователи с ролью Admin
        public ActionResult AdminPanel()
        {
            ViewBag.Message = "Admin Panel.";

            return View();
        }

        public ActionResult DeleteUser(int id = 0)
        {
            var user = userprofile.UserProfiles.ToList();
            SimpleRoleProvider roles = (SimpleRoleProvider)Roles.Provider;
            SimpleMembershipProvider membership = (SimpleMembershipProvider)Membership.Provider;

            UserProfile profile = userprofile.UserProfiles.Find(id);

            if (profile == null)
            {
                return View(user);
            }
            else
            {


                var roole = roles.GetRolesForUser(profile.UserName);
                roles.RemoveUsersFromRoles(new[] { profile.UserName }, roole);
                membership.DeleteUser(profile.UserName, true);

                var autorised = Request.IsAuthenticated ? User.Identity.Name : "nothing";
                if (autorised == profile.UserName)
                {
                    WebSecurity.Logout();
                }

                TempData["_UserRole"] = "Prosto";
                return RedirectToAction("DeleteUser");
            }


        }
    }
}
