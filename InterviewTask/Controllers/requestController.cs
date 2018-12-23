
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
        unitOfWork UOW = new unitOfWork();
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
        
        public async Task<IHttpActionResult> Get(int id)
        {
            Repositry<usersrole> userRoleRepositry = UOW.GetReposityInstance<usersrole>();  //repositry for table user role
            IEnumerable<usersrole> usesrRolesAll=await userRoleRepositry.GetAll();//get all data
            IEnumerable<usersrole> RolesOfuser = usesrRolesAll.Where(ur => ur.UserId == id); //filter for just user

            IEnumerable<request> AllRequests = await Repo.GetAll();  //get all requests
            List<request> requests = new List<request>();
            foreach (usersrole ur in RolesOfuser) {
                requests.AddRange(AllRequests.Where(AR => AR.role == ur.Roleid));  //get requests with this role
            }
            
            return Ok(requests);
        }
        public async Task<IHttpActionResult> Post(request req)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    request modireq = await Repo.GetEntity(req.Id);
                    if (modireq != null)
                    {
                        Repo.Update(req);
                    }
                    else
                    {
                        Repo.Add(new request() { requestTitle=req.requestTitle,requestBody=req.requestBody });
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
