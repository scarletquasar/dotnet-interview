using System.Collections.Generic;
using System.Threading.Tasks;
using SecureFlight.Core.Entities;

namespace SecureFlight.Core.Interfaces;

public interface IFlightService<TEntity>
	where TEntity : class
{
	Task<TEntity> AddPassenger(long id, Passenger passenger);
	Task<OperationResult<IReadOnlyList<TEntity>>> GetAllAsync();
	Task<TEntity> GetById(long id);
}