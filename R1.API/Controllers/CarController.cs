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
using R1.Services.API.Models.Dto;

namespace R1.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository carRepository;
        private readonly IMapper mapper;
        private readonly ILogger<SessionController> logger;

        public CarController(ICarRepository carRepository, IMapper mapper, ILogger<SessionController> logger)
        {
            this.carRepository = carRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: api/shareholders/CurrentEngine
        [HttpGet("CurrentEngine")]
        public async Task<ActionResult<ResponseDto>> GetCurrentEngine()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                
                var currentEngine = await carRepository.GetCurrentEngineAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = currentEngine;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetCurrentEngine)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/shareholders/CurrentChassis
        [HttpGet("CurrentChassis")]
        public async Task<ActionResult<ResponseDto>> GetCurrentChassis()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var currentChassis = await carRepository.GetCurrentChassisAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = currentChassis;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetCurrentChassis)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/shareholders/AvailableEngines
        [HttpGet("AvailableEngines")]
        public async Task<ActionResult<ResponseDto>> GetAvailableEngines()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var availableEngines = await carRepository.GetAvailableEnginesAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = availableEngines;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetAvailableEngines)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/shareholders/CurrentChassis
        [HttpGet("AvailableChassis")]
        public async Task<ActionResult<ResponseDto>> GetAvailableChassis()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var availableChassis = await carRepository.GetAvailableChassisAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = availableChassis;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetAvailableChassis)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }



        // POST: api/shareholders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PurchaseEngine")]
        public async Task<ActionResult<ResponseDto>> PurchaseEngine(PurchaseEngineDto engine)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                var results = await carRepository.PurchaseEngineAsync(engine.engineId);

                resp.Result = results;
                resp.IsSuccess = true;
                resp.Message = "The engine was purchased successfully.";
                return resp;
            }
            catch (Exception ex)
            {
                ResponseDto resp = new ResponseDto();
                logger.LogError(ex, $"Error Performing POST in {nameof(PurchaseEngine)}", engine);
                resp.IsSuccess = false;
                resp.Message = ex.Message;
                return resp;
            }
            
        }

        // POST: api/shareholders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PurchaseChassis")]
        public async Task<ActionResult<ResponseDto>> PurchaseChassis(PurchaseChassisDto chassis)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                var results = await carRepository.PurchaseChassisAsync(chassis.chassisId);
                resp.Result = results;
                resp.IsSuccess = true;
                resp.Message = "The chassis was purchased successfully.";
                return resp;
                //return CreatedAtAction(nameof(PurchaseChassis), new {  }, chassis.chassisId);
            }
            catch (Exception ex)
            {
                ResponseDto resp = new ResponseDto();
                logger.LogError(ex, $"Error Performing POST in {nameof(PurchaseChassis)}", chassis);
                resp.IsSuccess = false;
                resp.Message = ex.Message;
                return resp;
            }
        }

        // GET: api/shareholders/PartStatus
        [HttpGet("PartStatus")]
        public async Task<ActionResult<ResponseDto>> GetPartStatus()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var partStatus = await carRepository.GetPartStatusAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = partStatus;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetPartStatus)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/shareholders/AvailableParts
        [HttpGet("AvailableParts")]
        public async Task<ActionResult<ResponseDto>> GetAvailableParts()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var availableParts = await carRepository.GetAvailablePartsAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = availableParts;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetAvailableParts)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }
    }
}
