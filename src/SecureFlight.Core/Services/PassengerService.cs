using System.Collections.Generic;
using System.Threading.Tasks;
using SecureFlight.Core.Entities;
using SecureFlight.Core.Interfaces;

namespace SecureFlight.Core.Services;

public class PassengerService : IPassengerService<Passenger>
{
    private readonly IPassengerRepository<Passenger> _repository;

    public PassengerService(IPassengerRepository<Passenger> repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult<IReadOnlyList<Passenger>>> GetAllAsync()
    {
        return new OperationResult<IReadOnlyList<Passenger>>(
            await _repository.GetAllAsync());
    }

    public async Task<Passenger> GetById(string id)
    {
        return await _repository.GetById(id);
    }
}