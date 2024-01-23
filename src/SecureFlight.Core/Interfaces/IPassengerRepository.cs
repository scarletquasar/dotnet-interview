using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecureFlight.Core.Interfaces;

public interface IPassengerRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    Task<TEntity> GetById(string id);
}