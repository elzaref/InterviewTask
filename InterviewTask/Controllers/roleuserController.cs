using InterviewTask.databaselayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ClassLibrarydatabaseModel;
using System.Threading.Tasks;

namespace InterviewTask.Controllers
{
    public class roleuserController : ApiController
    {
        unitOfWork UOW = new unitOfWork();  //instance of unit of work to get repositry instance and united save in case roll back
        Repositry<usersrole> Repo;
        public roleuserController()
        {
            Repo = UOW.GetReposityInstance<usersrole>();
        }
        public IHttpActionResult Post(role_user_id obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int id = int.Parse(obj.roleid);
                     Repo.Add(new usersrole() {UserId=obj.userid,Roleid=id });// for new user
                     UOW.Save();
                    
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
                return BadRequest();
        }
        
    }
}
