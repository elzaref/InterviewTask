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
        unitOfWork UOW = new unitOfWork();  //instance of unit of work to get repositry instance and united save in case roll back
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
        // for check if is user
        // this solution for generic generic repositry and async 
        public async Task<IHttpActionResult> GetuserByName_Password(string name,string password)
        {
            IEnumerable<user> users = await Get();
            user user = users.Where(one => (one.Username == name) && (one.password == password)).FirstOrDefault();
            if (user != null)
                return Ok(user);
            return NotFound();
        }
        public async Task<IHttpActionResult> Post(user user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    user modiUser = await Repo.GetEntity(user.Id);
                    if (modiUser != null)// for update
                    {
                        Repo.Update(user);
                    }
                    else
                    {
                        Repo.Add(user);// for new user
                        UOW.Save();
                    }
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
        // for delete user
        public async Task<IHttpActionResult> Delete(int id)
        {
            user user = await Repo.GetEntity(id);
            if (user != null)
            {
                Repo.Delete(user);
                UOW.Save();
                return Ok();
            }
            return NotFound();
        }
    }
}
