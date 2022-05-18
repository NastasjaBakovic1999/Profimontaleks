using Profimontaleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.DataAccess.Implementation
{
    public class RepositoryPosition : IRepositoryPosition
    {
        private readonly ProfimontaleksContext context;

        public RepositoryPosition(ProfimontaleksContext context)
        {
            this.context = context;
        }

        public List<Position> GetAll()
        {
            try
            {
                return context.Positions.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
