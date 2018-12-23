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
        // for client to create request just title and body 
        public ActionResult index()
        {
            ViewBag.Title = "Create request";

            return View();
        }

    }
}
