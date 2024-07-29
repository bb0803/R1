﻿using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.Data;

namespace R1.FrontEnd.Web.Services.Interfaces
{
    public interface IDevelopmentService
    {
        Task<ResponseDto?> StartTaskAsync(int taskId);
        Task<ResponseDto?> EndOfRoundAsync();
    }
}
