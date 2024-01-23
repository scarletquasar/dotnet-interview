using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureFlight.Api.Models;
using SecureFlight.Api.Utils;
using SecureFlight.Core.Entities;
using SecureFlight.Core.Interfaces;

namespace SecureFlight.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : SecureFlightBaseController
{
	private readonly IFlightService<Flight> _flightService;
	private readonly IPassengerService<Passenger> _passengerService;

	public FlightsController(
		IPassengerService<Passenger> passengerService,
		IFlightService<Flight> flightService,
		IMapper mapper)
		: base(mapper)
	{
		_passengerService = passengerService;
		_flightService = flightService;
	}

	[HttpGet]
	[ProducesResponseType(typeof(IEnumerable<FlightDataTransferObject>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponseActionResult))]
	public async Task<IActionResult> Get()
	{
		var flights = await _flightService.GetAllAsync();
		return GetResult<IReadOnlyList<Flight>, IReadOnlyList<FlightDataTransferObject>>(flights);
	}

	[HttpPut("AddPassenger")]
	public async Task<IActionResult> AddPassenger(
		[FromBody] string id,
		[FromQuery] long flightId)
	{
		var passenger = await _passengerService.GetById(id);
		var result = await _flightService.AddPassenger(flightId, passenger);

		if (result is null)
		{
			return NotFound("Flight not found");
		}

		return Ok();
	}

}