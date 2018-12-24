using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


using ClassLibrarydatabaseModel;
namespace InterviewTask.databaselayer
{
    public class Repositry<Tentity> : IRepositry<Tentity> where Tentity : class
    {
        private readonly DbSet<Tentity> dbSet;
        private readonly taskEntities db;
        public Repositry(taskEntities Db)
        {
            db = Db;
            dbSet = db.Set<Tentity>();
        }

        public void Add(Tentity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(Tentity entity)
        {
            if (db.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);
            dbSet.Remove(entity);
        }

        public async Task<IEnumerable<Tentity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Tentity> GetEntity(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public Tentity GetEntityByID(int id)
        {
            return  dbSet.Find(id);
        }
        public void Update(Tentity entity)
        {
            dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
        }
    }

}