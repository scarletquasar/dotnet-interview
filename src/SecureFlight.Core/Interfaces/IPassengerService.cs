using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureFlight.Core.Interfaces;

public interface IPassengerService<TEntity> : IService<TEntity>
    where TEntity : class
{
    Task<TEntity> GetById(string id);
}