using Profimontaleks.Data;

namespace Profimontaleks.Services.Interfaces
{
    public interface IServiceWorker : IService<Worker>
    {
        public void Add(Worker worker);
        public void Update(Worker worker);
        public Worker GetById(int id);
    }
}
