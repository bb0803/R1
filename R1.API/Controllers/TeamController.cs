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
using R1.Services.API.Models.User;
using R1.Services.API.Models.Dto;

namespace R1.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository teamRepository;
        private readonly IMapper mapper;
        private readonly ILogger<TeamController> logger;

        public TeamController(ITeamRepository teamRepository, IMapper mapper, ILogger<TeamController> logger)
        {
            this.teamRepository = teamRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: api/team/availableStaff
        [HttpGet("AvailableStaff")]
        public async Task<ActionResult<ResponseDto>> GetAvailableStaffAsync()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var AvailableStaff = await teamRepository.GetAvailableStaffAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = AvailableStaff;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetAvailableStaffAsync)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/team/teamStatus
        [HttpGet("TeamStatus")]
        public async Task<ActionResult<ResponseDto>> GetTeamStatus()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var teamStatus = await teamRepository.GetTeamStatusAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = teamStatus;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetTeamStatus)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // POST: api/team/setupWorld
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("SetupWorld")]
        public async Task<ActionResult<UserSetting>> SetupWorld(string teamName, int classId)
        {
            try
            {
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                var user = await teamRepository.SetupWorldAsync(teamName, classId);

                return CreatedAtAction(nameof(SetupWorld), new { }, user);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(SetupWorld)}", classId);
                return StatusCode(500, Messages.Error500Message);
            }

        }

        // POST: api/team/postTransaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostTransaction")]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction tran)
        {
            try
            {
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                await teamRepository.PostTransactionAsync(tran);

                return CreatedAtAction(nameof(PostTransaction), new { }, tran);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(PostTransaction)}", tran);
                return StatusCode(500, Messages.Error500Message);
            }
        }


        // POST: api/shareholders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("SackStaff")]
        public async Task<ActionResult<Engine>> SackStaff(int staffId)
        {
            try
            {
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                await teamRepository.SackStaffAsync(staffId);

                return CreatedAtAction(nameof(SackStaff), new { }, staffId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(SackStaff)}", staffId);
                return StatusCode(500, Messages.Error500Message);
            }

        }

        // POST: api/shareholders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("HireStaff")]
        public async Task<ActionResult<Chassis>> HireStaff(AvailableStaffDto staff)
        {
            try
            {
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                await teamRepository.HireStaffAsync(staff);

                return CreatedAtAction(nameof(HireStaff), new { }, staff);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(HireStaff)}", staff);
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // POST: api/team/changeCarSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ChangeCarSettings")]
        public async Task<ActionResult<Engine>> ChangeCarSettings()
        {
            try
            {
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                await teamRepository.ChangeCarSettingsAsync();

                return CreatedAtAction(nameof(ChangeCarSettings), new { });
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
        public async Task<ActionResult<Chassis>> ChangeDriverSettings(int driverId)
        {
            try
            {
                //var sessionLapTime = mapper.Map<SessionLapTime>(sessionLapTimeDto);
                await teamRepository.ChangeDriverSettingsAsync(driverId);

                return CreatedAtAction(nameof(ChangeDriverSettings), new { }, driverId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(ChangeDriverSettings)}", driverId);
                return StatusCode(500, Messages.Error500Message);
            }
        }

        


    }
}
