using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.databaselayer
{
    interface IRepositry<Tentity> where Tentity : class
    {
        Task<IEnumerable<Tentity>> GetAll();
        Task<Tentity> GetEntity(int id);

        void Add(Tentity entity);

        void Update(Tentity entity);

        void Delete(Tentity entity);
    }
}
