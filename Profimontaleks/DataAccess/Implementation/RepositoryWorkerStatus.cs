using Profimontaleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.DataAccess.Implementation
{
    public class RepositoryWorkerStatus : IRepositoryWorkerStatus
    {
        private readonly ProfimontaleksContext context;

        public RepositoryWorkerStatus(ProfimontaleksContext context)
        {
            this.context = context;
        }

        public List<WorkerStatus> GetAll()
        {
            try
            {
                return context.WorkerStatuses.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
