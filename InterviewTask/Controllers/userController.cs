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
    
    public class userController : ApiController
    {
        unitOfWork UOW = new unitOfWork();
        Repositry<user> Repo;
        public userController()
        {
            Repo = UOW.GetReposityInstance<user>();
        }
        public async Task<IEnumerable<user>> Get()
        {
            IEnumerable<user> users = await Repo.GetAll();
            return users;
        }
        
        public async Task<IHttpActionResult> Get(int id)
        {
            user user = await Repo.GetEntity(id);
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IHttpActionResult> Post(user user)
        {
            try
            {
                user modiUser = await Repo.GetEntity(user.Id);
                if (modiUser != null)
                {
                    Repo.Update(user);
                }
                else
                {
                    Repo.Add(user);
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            user user = await Repo.GetEntity(id);
            if (user != null)
            {
                Repo.Delete(user);
                return Ok();
            }
            return NotFound();
        }
    }
}
