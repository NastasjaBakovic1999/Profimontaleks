using Profimontaleks.Data;

namespace Profimontaleks.DataAccess
{
    public interface IRepositoryWorker : IRepository<Worker>
    {
        public void Add(Worker worker); 
        public void Update(Worker worker);  
        public Worker GetById(int id);

    }
}
