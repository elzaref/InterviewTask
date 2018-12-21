using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClassLibrarydatabaseModel;
namespace InterviewTask.databaselayer
{
    public class unitOfWork
    {
        private taskEntities dbTask = new taskEntities();
        public Repositry<Tentity> GetReposityInstance<Tentity>() where Tentity : class
        {
            return new Repositry<Tentity>(dbTask);
        }
        public void Save()
        {
            dbTask.SaveChanges();
        }
    }
}