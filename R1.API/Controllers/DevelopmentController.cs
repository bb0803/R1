using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using R1.Services.API.Models.Data;
using R1.Services.API.Models.DTO;
using R1.Services.API.Static;
using R1.Services.API.Repositories.Interfaces;

namespace R1.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DevelopmentController : ControllerBase
    {
        private readonly IDevelopmentRepository developmentRepository;
        private readonly IMapper mapper;
        private readonly ILogger<DevelopmentController> logger;

        public DevelopmentController(IDevelopmentRepository developmentRepository, IMapper mapper, ILogger<DevelopmentController> logger)
        {
            this.developmentRepository = developmentRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        // PUT: api/development/startTask/id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("StartTask")]
        public async Task<IActionResult> StartTask(int id)
        {

            var startTask = await developmentRepository.StartTask(id);

            if (startTask == null)
            {
                logger.LogWarning($"{nameof(StartTask)} record not found in {nameof(startTask)} - ID: {id}");
                return NotFound();
            }

            //mapper.Map(sessionLapTimeDto, sessionLapTime);

            //try
            //{
            //    await sessionLapTimesRepository.UpdateAsync(sessionLapTime);
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    if (!await sessionLapTimeExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        logger.LogError(ex, $"Error Performing GET in {nameof(PutSessionLapTime)}");
            //        return StatusCode(500, Messages.Error500Message);
            //    }
            //}

            return NoContent();
        }


        // PUT: api/development/endofround
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("EndOfRound")]
        public async Task<IActionResult> EndOfRound()
        {

            var endOfRound = await developmentRepository.EndOfRound();

            if (endOfRound == null)
            {
                logger.LogWarning($"{nameof(EndOfRound)} record not found in {nameof(EndOfRound)}");
                return NotFound();
            }

            //mapper.Map(sessionLapTimeDto, sessionLapTime);

            //try
            //{
            //    await sessionLapTimesRepository.UpdateAsync(sessionLapTime);
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    if (!await sessionLapTimeExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        logger.LogError(ex, $"Error Performing GET in {nameof(PutSessionLapTime)}");
            //        return StatusCode(500, Messages.Error500Message);
            //    }
            //}

            return NoContent();
        }


    }
}
