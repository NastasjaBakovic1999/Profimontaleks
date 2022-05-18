using Profimontaleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.DataAccess.Implementation
{
    public class RepositoryPhaseStatus : IRepositoryPhaseStatus
    {
        private readonly ProfimontaleksContext context;

        public RepositoryPhaseStatus(ProfimontaleksContext context)
        {
            this.context = context;
        }

        public List<PhaseStatus> GetAll()
        {
            try
            {
                return context.PhaseStatuses.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
