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
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository resultRepository;
        private readonly IMapper mapper;
        private readonly ILogger<ResultController> logger;

        public ResultController(IResultRepository sessionLapTimesRepository, IMapper mapper, ILogger<ResultController> logger)
        {
            this.resultRepository = resultRepository;
            this.mapper = mapper;
            this.logger = logger;
        }


        // GET: api/shareholders/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseDto>> GetSessionLapTimes()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                
                var sessionLapTimes = await resultRepository.GetSessionLapTimesAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = sessionLapTimes;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetSessionLapTimes)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/shareholders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> GetSessionLapTime(int id)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var sessionLapTime = await resultRepository.GetSessionLapTimeDetailsAsync(id);

                if (sessionLapTime == null)
                {
                    logger.LogWarning($"Record Not Found: {nameof(GetSessionLapTime)} - ID: {id}");
                    return NotFound();
                }
                resp.Result = sessionLapTime;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetSessionLapTime)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

    }
}
