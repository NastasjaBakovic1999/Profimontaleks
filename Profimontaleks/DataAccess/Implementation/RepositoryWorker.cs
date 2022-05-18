using Profimontaleks.Data;
using System.Collections.Generic;

namespace Profimontaleks.DataAccess.Implementation
{
    public class RepositoryWorker : IRepositoryWorker
    {
        private readonly ProfimontaleksContext context;

        public RepositoryWorker(ProfimontaleksContext context)
        {
            this.context = context;
        }

        public void Add(Worker worker)
        {
            throw new System.NotImplementedException();
        }

        public List<Worker> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Worker GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Worker worker)
        {
            throw new System.NotImplementedException();
        }
    }
}
