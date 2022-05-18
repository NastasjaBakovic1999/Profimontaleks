using Profimontaleks.Data;
using Profimontaleks.DataAccess.UnitOfWork;
using Profimontaleks.Services.Interfaces;
using System.Collections.Generic;

namespace Profimontaleks.Services.Implementation
{
    public class ServicePosition : IServicePosition
    {
        private readonly IUnitOfWork unitOfWork;

        public ServicePosition(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Position> GetAll()
        {
            return unitOfWork.Position.GetAll();
        }
    }
}
