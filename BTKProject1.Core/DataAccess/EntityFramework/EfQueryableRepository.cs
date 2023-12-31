﻿using BTKProject1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKProject1.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<T> Table => this.Entites;

        protected virtual IDbSet<T> Entites
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }
    }
}
