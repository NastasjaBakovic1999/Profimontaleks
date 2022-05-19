using Profimontaleks.Data;

namespace Profimontaleks.DataAccess
{
    public interface IReposiotyPhase : IRepository<Phase>
    {
        public Phase GetById(int Id);
    }
}
