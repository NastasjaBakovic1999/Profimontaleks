using Microsoft.EntityFrameworkCore;
using Profimontaleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.DataAccess.Implementation
{
    public class RepositoryProductCardboardPhase : IRepositoryProductCardboardPhase
    {
        private readonly ProfimontaleksContext context;

        public RepositoryProductCardboardPhase(ProfimontaleksContext context)
        {
            this.context = context;
        }
        public void Add(ProductCardboardPhase productCardboardPhase)
        {
            try
            {
                context.ProductCardboardPhases.Add(productCardboardPhase);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int PCCNumber, int id)
        {
            try
            {
                var prp = context.ProductCardboardPhases.FirstOrDefault(x => x.PCCNumber == PCCNumber && x.PhaseId == id);
                context.ProductCardboardPhases.Remove(prp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProductCardboardPhase> GetAll()
        {
            try
            {
                return context.ProductCardboardPhases.Include(p =>p.ProductCardboard)
                                                      .Include(p => p.Phase)
                                                      .Include(p => p.Status)
                                                      .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProductCardboardPhase> GetAllByPCCNumber(int PCCNumber)
        {
            try
            {
                var phases = context.ProductCardboardPhases.Include(x => x.Status)
                                                           .Include(x => x.Phase)
                                                           .Include(x => x.ProductCardboard)
                                                           .Where(p => p.PCCNumber == PCCNumber);
                if (phases != null)
                {
                    return phases.ToList();
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProductCardboardPhase GetById(int PCCNumber, int Id)
        {
            try
            {
                return context.ProductCardboardPhases.Include(x => x.Status).FirstOrDefault(x=> x.PCCNumber == PCCNumber && x.PhaseId == Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ProductCardboardPhase productCardboardPhase)
        {
            try
            {
                context.ProductCardboardPhases.Update(productCardboardPhase);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
