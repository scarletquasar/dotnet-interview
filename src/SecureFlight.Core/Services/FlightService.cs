using System.Collections.Generic;
using System.Threading.Tasks;
using SecureFlight.Core.Entities;
using SecureFlight.Core.Interfaces;

namespace SecureFlight.Core.Services;

public class FlightService : IFlightService<Flight>
{
	private readonly IFlightRepository<Flight> _repository;

	public FlightService(IFlightRepository<Flight> repository)
	{
		_repository = repository;
	}

	public async Task<Flight> AddPassenger(long id, Passenger passenger)
	{
		var flight = await GetById(id);

		if (flight is null)
		{
			return null;
		}

		flight.Passengers.Add(passenger);

		var result = _repository.Update(flight);
		return result;
	}

	public async Task<OperationResult<IReadOnlyList<Flight>>> GetAllAsync()
	{
		return new OperationResult<IReadOnlyList<Flight>>(
			await _repository.GetAllAsync());
	}

	public async Task<Flight> GetById(long id)
	{
		return await _repository.GetById(id);
	}
}