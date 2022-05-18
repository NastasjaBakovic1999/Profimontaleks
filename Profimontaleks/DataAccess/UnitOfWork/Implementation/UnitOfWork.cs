using Profimontaleks.Data;
using Profimontaleks.DataAccess.Implementation;

namespace Profimontaleks.DataAccess.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProfimontaleksContext context;

        public UnitOfWork(ProfimontaleksContext context)
        {
            this.context = context;
            Phase = new RepositoryPhase(context);
            PhaseStatus = new RepositoryPhaseStatus(context);
            Position = new RepositoryPosition(context);
            Product = new RepositoryProduct(context);
            ProductCardboard = new RepositoryProductCardboard(context);
            ProductType = new RepositoryProductType(context);
            Worker = new RepositoryWorker(context);
            WorkerStatus = new RepositoryWorkerStatus(context);
        }

        public IReposiotyPhase Phase { get; set; }
        public IRepositoryPhaseStatus PhaseStatus { get; set; }
        public IRepositoryPosition Position { get; set; }
        public IRepositoryProduct Product { get; set; }
        public IRepositoryProductCardboard ProductCardboard { get; set; }
        public IRepositoryProductCardboardPhase ProductCardboardPhase { get; set; }
        public IRepositoryProductType ProductType { get; set; }
        public IRepositoryWorker Worker { get; set; }
        public IRepositoryWorkerStatus WorkerStatus { get; set; }

        public void Commit()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
