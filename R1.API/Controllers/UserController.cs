using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using R1.Services.API.Models.Data;
using R1.Services.API.Models.User;
using R1.Services.API.Static;
using R1.Services.API.Repositories.Interfaces;
using R1.Services.API.Repositories.Implementations;
using R1.Services.API.Models.DTO;

namespace R1.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ILogger<UserController> logger;

        public UserController(IUserRepository userRepository, IMapper mapper, ILogger<UserController> logger)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        // PUT: api/user/changeWorld/id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("ChangeWorld")]
        public async Task<IActionResult> ChangeWorld(int worldId)
        {
            var userSettingDto = userRepository.GetUserSetting();

            if (userSettingDto == null)
            {
                logger.LogWarning($"{nameof(userSettingDto)} record not found in {nameof(ChangeWorld)}");
                return NotFound();
            }

            UserSetting userSetting = new UserSetting();

            userSetting.CurrentWorldId = worldId;

            mapper.Map(userSettingDto, userSetting);

            try
            {
                await userRepository.UpdateAsync(userSetting);
            }
            catch (Exception ex)
            {


            }
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    if (!await shareholderExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        logger.LogError(ex, $"Error Performing GET in {nameof(PutShareholder)}");
            //        return StatusCode(500, Messages.Error500Message);
            //    }
            //}

            return NoContent();

        }

        // GET: api/shareholders/CurrentEngine
        [HttpGet("CheckStatus")]
        public async Task<ActionResult<ResponseDto>> CheckStatus()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var checkStatus = await userRepository.CheckStatus();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = checkStatus;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(CheckStatus)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }



    }
}
