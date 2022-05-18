using System;

namespace Profimontaleks.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IReposiotyPhase Phase { get; set; }
        public IRepositoryPhaseStatus PhaseStatus { get; set; } 
        public IRepositoryPosition PhasePosition { get; set; }  
        public IRepositoryProduct Product { get; set; }
        public IRepositoryProductCardboard ProductCardboard { get; set; }
        public IRepositoryProductCardboardPhase ProductCardboardPhase { get; set; }
        public IRepositoryProductType ProductType { get; set; }
        public IRepositoryWorker Worker { get; set; }
        public IRepositoryWorkerStatus WorkerStatus { get; set; }
        void Commit();
    }
}
