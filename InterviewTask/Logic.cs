using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrarydatabaseModel;
using InterviewTask.Controllers;

namespace InterviewTask
{
    public class Logic
    {
        public bool loged(user user,object sessionValue)
        {
            if ((user != null) && (user.Username != null) && sessionValue == null)
            {
                return true;
            }
            return false;
        }
        public List<SelectListItem> roles()
        {
            //instead of database because time 
            List<SelectListItem> listitem = new List<SelectListItem>();
            listitem.Add(
                new SelectListItem
                {
                    Text = "role A",
                    Value = "1"
                }
                );
            listitem.Add(
                new SelectListItem
                {
                    Text = "role B",
                    Value = "2"
                }
                );
            return listitem;
        }
        public user GetUserById(int id)
        {
            userController uc = new userController();
            return uc.GetUserByID(id);
        }

    }
}