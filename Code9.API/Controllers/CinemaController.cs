﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code9.API.Models;
using Code9.Domain.Models;
using Code9.Domain.Commands;
using Code9.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Code9.Domain.Handlers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<List<Cinema>> GetAllCinemas()
        {
            var cinemas = _mediator.Send(new GetAllCinemasQuery());
            return Ok(cinemas);
        }

        [HttpPost]
        public async Task<ActionResult<Cinema>> AddCinema(AddCinemaRequest addCinemaRequest)
        {
            var addCinemaCommand = new AddCinemaCommand
            { 
                Name = addCinemaRequest.Name,
                City = addCinemaRequest.City,
                Street = addCinemaRequest.Street,
                NumberOfAuditoriums = addCinemaRequest.NumberOfAuditoriums
            };

            var cinema = _mediator.Send(addCinemaCommand);
            return CreatedAtAction(nameof(GetAllCinemas), new { id = cinema.Id }, cinema);
        }
    }
}
