﻿using Microsoft.EntityFrameworkCore;
using Profimontaleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.DataAccess.Implementation
{
    public class RepositoryWorker : IRepositoryWorker
    {
        private readonly ProfimontaleksContext context;

        public RepositoryWorker(ProfimontaleksContext context)
        {
            this.context = context;
        }

        public void Add(Worker worker)
        {
            try
            {
                context.Workers.Add(worker);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Worker> GetAll()
        {
            try
            {
                return context.Workers.Include(x => x.Position).Include(x=>x.Status).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Worker GetById(int id)
        {
            try
            {
                return context.Workers.Include(x => x.Position).Include(x => x.Status).SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Worker worker)
        {
            try
            {
                context.Workers.Update(worker);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
