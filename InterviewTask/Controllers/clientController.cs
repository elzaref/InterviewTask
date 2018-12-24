using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrarydatabaseModel;
namespace InterviewTask.Controllers
{

    public class clientController : Controller
    {
        Logic logic = new Logic();
        // for client to create request just title and body 
        public ActionResult index()
        {
            ViewBag.Title = "Create request";

            return View();
        }
        
        public ActionResult Users()
        {
            
            ViewBag.Title = "Assign User To Role";
            return View();
        }
        public ActionResult assignUserToRole(int id)
        {
            user user = logic.GetUserById(id);
            ViewData.Add("Roles", logic.roles());
            ViewData.Add("user", user);
            ViewBag.Title = "Assign User To Role";
            return View();
        }


    }
}
