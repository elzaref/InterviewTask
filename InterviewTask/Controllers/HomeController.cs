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

        Logic logic = new Logic();// check for logic or business
       //to show every employee his group requests
        public ActionResult Index(user user)
        {
            
            ViewBag.Title = "Home Page";
            object sessionValue = Session["loged"];
            if (logic.loged(user, sessionValue))//check to create session because when user login it redirect to this action index
                Session["loged"] = user;

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
        //to create new employee user
        public ActionResult Register()
        {
            if (Session["loged"] == null)// if already login go to requests page 
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
