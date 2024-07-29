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
using Microsoft.Extensions.Logging;
using R1.Services.API.Models.Dto;

namespace R1.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository driverRepository;
        private readonly IMapper mapper;
        private readonly ILogger<DriverController> logger;

        public DriverController(IDriverRepository driverRepository, IMapper mapper, ILogger<DriverController> logger)
        {
            this.driverRepository = driverRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: api/driver/teamDrivers
        [HttpGet("TeamDrivers")]
        public async Task<ActionResult<ResponseDto>> GetTeamDrivers()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var teamDrivers = await driverRepository.GetTeamDriversAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = teamDrivers;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetTeamDrivers)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/driver/availableDrivers
        [HttpGet("AvailableDrivers")]
        public async Task<ActionResult<ResponseDto>> GetAvailableDrivers()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var availableChassis = await driverRepository.GetAvailableDriversAsync();
                resp.Result = availableChassis;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetAvailableDrivers)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // POST: api/driver/hiredriver
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("HireDriver")]
        public async Task<ActionResult<ResponseDto>> HireDriver(HireDriverDto driver)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var results = await driverRepository.HireDriverAsync(driver.driverId);

                resp.Result = results;
                resp.IsSuccess = true;
                resp.Message = "The driver was hired successfully.";
                return resp;
            }
            catch (Exception ex)
            {
                ResponseDto resp = new ResponseDto();
                logger.LogError(ex, $"Error Performing POST in {nameof(HireDriver)}", driver);
                resp.IsSuccess = false;
                resp.Message = ex.Message;
                return resp;
            }
        }

        // POST: api/driver/sackDriver
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("SackDriver")]
        public async Task<ActionResult<ResponseDto>> SackDriver(HireDriverDto driver)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var results = await driverRepository.SackDriverAsync(driver.driverId);

                resp.Result = results;
                resp.IsSuccess = true;
                resp.Message = "The driver was fired successfully.";
                return resp;
            }
            catch (Exception ex)
            {
                ResponseDto resp = new ResponseDto();
                logger.LogError(ex, $"Error Performing POST in {nameof(HireDriver)}", driver);
                resp.IsSuccess = false;
                resp.Message = ex.Message;
                return resp;
            }
        }

    }
}
