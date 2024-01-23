using System.Threading.Tasks;

namespace SecureFlight.Core.Interfaces;

public interface IFlightRepository<TEntity> : IRepository<TEntity>
	where TEntity : class
{
	Task<TEntity> GetById(long id);
}