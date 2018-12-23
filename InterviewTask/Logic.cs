using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClassLibrarydatabaseModel;
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

    }
}