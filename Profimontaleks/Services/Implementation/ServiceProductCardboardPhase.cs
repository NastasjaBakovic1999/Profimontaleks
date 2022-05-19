using Profimontaleks.Data;
using Profimontaleks.DataAccess.UnitOfWork;
using Profimontaleks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.Services.Implementation
{
    public class ServiceProductCardboardPhase : IServiceProductCardboardPhase
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceProductCardboardPhase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(ProductCardboardPhase productCardboardPhase)
        {
            if (!IsValid(productCardboardPhase) || AlreadyExistInDB(productCardboardPhase))
            {
                throw new ArgumentOutOfRangeException("Invalid entry!");
            }
            unitOfWork.ProductCardboardPhase.Add(productCardboardPhase);
            unitOfWork.Commit();
        }

        private bool IsValid(ProductCardboardPhase productCardboardPhase)
        {
            bool valid = true;

            if (productCardboardPhase == null) return false;
            if(productCardboardPhase.PCCNumber == 0 || productCardboardPhase.PhaseId == 0 || productCardboardPhase.StatusId == 0)
            {
                return false;
            }

            return valid;
        }

        private bool AlreadyExistInDB(ProductCardboardPhase productCardboardPhase)
        {
            bool exist = false;

            if (unitOfWork.ProductCardboardPhase.GetAll().Any(a => a.PCCNumber == productCardboardPhase.PCCNumber &&
                                                                     a.PhaseId == productCardboardPhase.PhaseId))
            {
                return true;
            }

            return exist;
        }

        public List<ProductCardboardPhase> GetAll()
        {
            return unitOfWork.ProductCardboardPhase.GetAll();
        }

        public List<ProductCardboardPhase> GetAllByPCCNumber(int PCCNumber)
        {
            if(PCCNumber == 0) throw new ArgumentOutOfRangeException("Invalid entry!");
            return unitOfWork.ProductCardboardPhase.GetAllByPCCNumber(PCCNumber);
        }

        public ProductCardboardPhase GetById(int PCCNumber, int Id)
        {
            return unitOfWork.ProductCardboardPhase.GetById(PCCNumber, Id);
        }

        public void Update(ProductCardboardPhase productCardboardPhase)
        {
            if (!IsValid(productCardboardPhase))
            {
                throw new ArgumentOutOfRangeException("Invalid entry!");
            }
            unitOfWork.ProductCardboardPhase.Update(productCardboardPhase);
            unitOfWork.Commit();
        }

        public void Delete(int PCCNumber, int id)
        {
            unitOfWork.ProductCardboardPhase.Delete(PCCNumber, id);
            unitOfWork.Commit();
        }
    }
}
