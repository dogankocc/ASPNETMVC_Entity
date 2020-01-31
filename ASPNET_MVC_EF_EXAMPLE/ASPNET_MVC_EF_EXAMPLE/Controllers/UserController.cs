using ASPNET_MVC_EF_EXAMPLE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASPNET_MVC_EF_EXAMPLE.Controllers
{
    public class UserController : Controller
    {
        doantestEntities2 entities = new doantestEntities2();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserMaster user)
        {
            IEnumerable<int> users =  entities.UserMaster.Where(e => e.UserName == user.UserName && e.UserPassword == user.UserPassword).Select(e => e.UserID);
            if(users.Count() != 1)
            {
                return new HttpNotFoundResult();
            }
            /**remember me value in second parameter*/
            FormsAuthentication.SetAuthCookie(user.UserName, false);
            return RedirectToAction("Index","Personel");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}