using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecureFlight.Core.Entities;
using SecureFlight.Core.Interfaces;

namespace SecureFlight.Infrastructure.Repositories
{
	public class FlightRepository : IFlightRepository<Flight>
	{
		private readonly SecureFlightDbContext _context;

		public FlightRepository(SecureFlightDbContext context)
		{
			_context = context;
		}

		public async Task<IReadOnlyList<Flight>> GetAllAsync()
		{
			return await _context.Set<Flight>().ToListAsync();
		}

		public async Task<IReadOnlyList<Flight>> FilterAsync(Expression<Func<Flight, bool>> predicate)
		{
			return await _context.Set<Flight>().Where(predicate).ToListAsync();
		}

		public Flight Update(Flight entity)
		{
			var entry = _context.Entry(entity);
			entry.State = EntityState.Modified;
			_context.SaveChanges();
			return entity;
		}

		public async Task<Flight> GetById(long id)
		{
			return await _context.FindAsync<Flight>(id);
		}
	}
}
