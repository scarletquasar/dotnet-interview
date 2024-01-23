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
	public class PassengerRepository : IPassengerRepository<Passenger>
	{
		private readonly SecureFlightDbContext _context;

		public PassengerRepository(SecureFlightDbContext context)
		{
			_context = context;
		}

		public async Task<IReadOnlyList<Passenger>> GetAllAsync()
		{
			return await _context.Set<Passenger>().ToListAsync();
		}

		public async Task<IReadOnlyList<Passenger>> FilterAsync(Expression<Func<Passenger, bool>> predicate)
		{
			return await _context.Set<Passenger>().Where(predicate).ToListAsync();
		}

		public async Task<Passenger> GetById(string id)
		{
			var matches = await _context
				.Set<Passenger>()
				.Where(entity => entity.Id == id)
				.ToListAsync();

			return matches.FirstOrDefault();
		}

		public Passenger Update(Passenger entity)
		{
			var entry = _context.Entry(entity);
			entry.State = EntityState.Modified;
			_context.SaveChanges();
			return entity;
		}
	}
}
