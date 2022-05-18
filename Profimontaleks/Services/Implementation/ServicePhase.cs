using Profimontaleks.Data;
using Profimontaleks.DataAccess.UnitOfWork;
using Profimontaleks.Services.Interfaces;
using System.Collections.Generic;

namespace Profimontaleks.Services.Implementation
{
    public class ServicePhase : IServicePhase
    {
        private readonly IUnitOfWork unitOfWork;

        public ServicePhase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Phase> GetAll()
        {
            return unitOfWork.Phase.GetAll();
        }
    }
}
