using Profimontaleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.DataAccess.Implementation
{
    public class RepositoryPhase : IReposiotyPhase
    {
        private readonly ProfimontaleksContext context;

        public RepositoryPhase(ProfimontaleksContext profimontaleksContext)
        {
            this.context = profimontaleksContext;
        }

        public List<Phase> GetAll()
        {
            try
            {
                return context.Phases.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
