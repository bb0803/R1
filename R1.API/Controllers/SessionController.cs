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
using R1.Services.API.Repositories.Implementations;

namespace R1.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<SessionController> logger;

        public SessionController(ISessionRepository sessionRepository, IMapper mapper, ILogger<SessionController> logger)
        {
            this.sessionRepository = sessionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: api/shareholders/PracticeLap
        [HttpGet("PracticeLap")]
        public async Task<ActionResult<ResponseDto>> DoPracticeLap()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var lap = await sessionRepository.DoPracticeLapAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = lap;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(DoPracticeLap)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/shareholders/QualifyingLap
        [HttpGet("QualifyingLap")]
        public async Task<ActionResult<ResponseDto>> DoQualifyingLap()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var lap = await sessionRepository.DoQualifyingLapAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = lap;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(DoQualifyingLap)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/shareholders/RaceLap
        [HttpGet("RaceLap")]
        public async Task<ActionResult<ResponseDto>> DoRaceLap()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var lap = await sessionRepository.DoRaceLapAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = lap;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(DoRaceLap)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/session/grid
        [HttpGet("Grid")]
        public async Task<ActionResult<ResponseDto>> CreateGrid()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var grid = await sessionRepository.CreateGridAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = grid;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(CreateGrid)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }


        // POST: api/team/changeCarSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ChangeCarSettings")]
        public async Task<ActionResult<Chassis>> ChangeCarSettings(Chassis car)
        {
            try
            {
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                await sessionRepository.ChangeCarSettingAsync(car);

                return CreatedAtAction(nameof(ChangeCarSettings), new { }, car);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(ChangeCarSettings)}");
                return StatusCode(500, Messages.Error500Message);
            }

        }

        // POST: api/team/changeDriverSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ChangeDriverSettings")]
        public async Task<ActionResult<Driver>> ChangeDriverSettings(Driver drv)
        {
            try
            {
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                await sessionRepository.ChangeDriverSettingsAsync(drv);

                return CreatedAtAction(nameof(ChangeDriverSettings), new { }, drv);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(ChangeDriverSettings)}", drv);
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // POST: api/team/changeTyre
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ChangeTyre")]
        public async Task<ActionResult<RaceTyre>> ChangeTyre(int tyre)
        {
            try
            {
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                await sessionRepository.ChangeCarTyreAsync(tyre);

                return CreatedAtAction(nameof(ChangeTyre), new { }, tyre);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(ChangeTyre)}", tyre);
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // POST: api/team/pit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Pit")]
        public async Task<ActionResult<string>> Pit()
        {
            try
            {
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                await sessionRepository.PitAsync();

                return CreatedAtAction(nameof(Pit), new { });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(Pit)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }
    }
}
