using AthenticationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using System.Web.Security;

namespace AthenticationMVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(User U)
        {
            AuthenAuthoEntities OE = new AuthenAuthoEntities();
            var Count = OE.Users.Where(m => m.UserName == U.UserName && m.Password == U.Password).Count();
            if(Count == 0)
            {
                ViewBag.Msg = "invalid User";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(U.UserName, false);
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}