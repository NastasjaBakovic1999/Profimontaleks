using Profimontaleks.Data;
using Profimontaleks.DataAccess.UnitOfWork;
using Profimontaleks.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Profimontaleks.Services.Implementation
{
    public class ServiceProductCardboard : IServiceProductCardboard
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceProductCardboard(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(ProductCardboard productCardboard)
        {
            if (!IsValid(productCardboard))
            {
                throw new ArgumentOutOfRangeException("Invalid entry!");
            }
            unitOfWork.ProductCardboard.Add(productCardboard);
            unitOfWork.Commit();
        }

        private bool IsValid(ProductCardboard productCardboard)
        {
            bool valid = true;

            if (productCardboard == null) return false;
            if (productCardboard.StartDate > productCardboard.EndDate) return false;
            if (productCardboard.StartDate > DateTime.Today || productCardboard.EndDate > DateTime.Today) return false;
            if (productCardboard.ProductId == 0) return false;

            return valid;
        }

        public List<ProductCardboard> GetAll()
        {
            return unitOfWork.ProductCardboard.GetAll();
        }

        public ProductCardboard GetById(int PCCNumber)
        {
            if(PCCNumber == 0) throw new ArgumentOutOfRangeException("Invalid entry!");
            return unitOfWork.ProductCardboard.GetById(PCCNumber);
        }

        public void Update(ProductCardboard productCardboard)
        {
            if (!IsValid(productCardboard))
            {
                throw new ArgumentOutOfRangeException("Invalid entry!");
            }
            unitOfWork.ProductCardboard.Update(productCardboard);
            unitOfWork.Commit();
        }
    }
}
