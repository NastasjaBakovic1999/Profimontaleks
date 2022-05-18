using Profimontaleks.Data;
using Profimontaleks.DataAccess.UnitOfWork;
using Profimontaleks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.Services.Implementation
{
    public class ServiceWorker : IServiceWorker
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceWorker(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Worker worker)
        {
            if(!IsValid(worker) || AlreadyExistInDB(worker))
            {
                throw new ArgumentOutOfRangeException("Invalid entry!");
            }
            unitOfWork.Worker.Add(worker);
            unitOfWork.Commit();
        }

        private bool IsValid(Worker worker)
        {
            bool valid = true;

            if (worker == null) return false;
            if (string.IsNullOrEmpty(worker.JMBG) || string.IsNullOrEmpty(worker.NameAndSurname)) return false;
            if (worker.Coefficient < 0 || worker.Coefficient > 10) return false;
            if (worker.DateOfEmployment > DateTime.Today) return false;
            if(worker.WorkerStatusId == 0 || worker.PositionId == 0) return false;

            return valid;
        }

        private bool AlreadyExistInDB(Worker worker)
        {
            bool exist = false;

            if (unitOfWork.Worker.GetAll().Any(a => a.JMBG == worker.JMBG))
            {
                return true;
            }

            return exist;
        }

        public List<Worker> GetAll()
        {
            return unitOfWork.Worker.GetAll();
        }

        public Worker GetById(int id)
        {
            return unitOfWork.Worker.GetById(id);
        }

        public void Update(Worker worker)
        {
            if (!IsValid(worker))
            {
                throw new ArgumentOutOfRangeException("Invalid entry!");
            }
            unitOfWork.Worker.Update(worker);
            unitOfWork.Commit();
        }
    }
}
