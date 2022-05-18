using Profimontaleks.Data;
using Profimontaleks.DataAccess.UnitOfWork;
using Profimontaleks.Services.Interfaces;
using System.Collections.Generic;

namespace Profimontaleks.Services.Implementation
{
    public class ServiceWorkerStatus : IServiceWorkerStatus
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceWorkerStatus(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<WorkerStatus> GetAll()
        {
            return unitOfWork.WorkerStatus.GetAll();
        }
    }
}
