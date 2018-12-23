
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InterviewTask.databaselayer;
using ClassLibrarydatabaseModel;
using System.Threading.Tasks;

namespace InterviewTask.Controllers
{
    
    public class requestController : ApiController
    {
        unitOfWork UOW = new unitOfWork(); //instance of unit of work to get repositry instance and united save in case roll back
        Repositry<request> Repo;
        public requestController()
        {
            Repo = UOW.GetReposityInstance<request>();
        }
        public async Task<IEnumerable<request>> Get()
        {
            IEnumerable<request> req = await Repo.GetAll();
            return req;
        }
        //get all requests for user in condition role group
        public async Task<IHttpActionResult> Get(int userid)
        {
            // all this code because generic repositry  it is anti pattern  and because using async task
            Repositry<usersrole> userRoleRepositry = UOW.GetReposityInstance<usersrole>();  //repositry for table user role
            IEnumerable<usersrole> usesrRolesAll=await userRoleRepositry.GetAll();//get all data
            IEnumerable<usersrole> RolesOfuser = usesrRolesAll.Where(ur => ur.UserId == userid); //filter for just user

            IEnumerable<request> AllRequests = await Repo.GetAll();  //get all requests
            List<request> requests = new List<request>();
            foreach (usersrole ur in RolesOfuser) {
                requests.AddRange(AllRequests.Where(AR => AR.role == ur.Roleid));  //get requests with this role
            }
            
            return Ok(requests);
        }
        //in case create new task 
        // or update task by manager to assign it to group
        public async Task<IHttpActionResult> Post(request req)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    request modireq = await Repo.GetEntity(req.Id);
                    if (modireq != null)//for update
                    {
                        Repo.Update(req);
                    }
                    else
                    {
                        Repo.Add(new request() { requestTitle=req.requestTitle,requestBody=req.requestBody });//for new 
                        UOW.Save();
                    }
                    return Ok(new request());
                }
                catch(Exception e)
                {
                    return BadRequest();
                }
            }
            else
                return BadRequest();
        }
        // for delete task
        public async Task<IHttpActionResult> Delete(int id)
        {
            request req = await Repo.GetEntity(id);
            if (req != null)
            {
                Repo.Delete(req);
                UOW.Save();
                return Ok();
            }
            return NotFound();
        }
    }
}
