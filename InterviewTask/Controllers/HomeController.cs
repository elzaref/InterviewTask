using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrarydatabaseModel;
namespace InterviewTask.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index(user user)
        {
            
            ViewBag.Title = "Home Page";
            if ((user !=null)&&(user.Username != null)&&Session["loged"]==null)
            {
                Session.Add("loged", user);
            }
            if (Session["loged"] != null)
            {
                user u = ((user)Session["loged"]);
                ViewData.Add("currentUser", u.Username);
                ViewData.Add("userId", u.Id);
            }
            else
            {
                ViewData.Add("currentUser", "guest");
                ViewData.Add("userId", 0);
            }
            return View();
        }
        public ActionResult Register()
        {
            if (Session["loged"] == null)
            {
                ViewBag.Title = "Registeration Page";

                return View();
            }
            else
            {
                return Index((user)Session["loged"]);
            }
        }
        public ActionResult Login()
        {
            ViewBag.Title = "Login Page";

            return View();
        }

    }
}
