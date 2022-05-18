using Profimontaleks.Data;
using Profimontaleks.DataAccess.UnitOfWork;
using Profimontaleks.Services.Interfaces;
using System.Collections.Generic;

namespace Profimontaleks.Services.Implementation
{
    public class ServicePhaseStatus : IServicePhaseStatus
    {
        private readonly IUnitOfWork unitOfWork;

        public ServicePhaseStatus(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<PhaseStatus> GetAll()
        {
            return unitOfWork.PhaseStatus.GetAll();
        }
    }
}
