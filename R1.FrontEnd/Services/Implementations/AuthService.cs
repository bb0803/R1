using Blazored.LocalStorage;
using R1.FrontEnd.WA.Models.API;
using R1.FrontEnd.WA.Models.User;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using R1.FrontEnd.WA.Providers;
using R1.FrontEnd.WA.Services.Interfaces;
using R1.FrontEnd.WA.Static;

namespace R1.FrontEnd.WA.Services.Implementations
{
    public class AuthService: IAuthService
    {
        private readonly IBaseService _baseService;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ITokenProvider _tokenProvider;

        public AuthService(IBaseService baseService, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider, ITokenProvider tokenProvider)
        {
            _baseService = baseService;
            _localStorage = localStorage;
            this._authenticationStateProvider = authenticationStateProvider;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Static.StaticDescriptions.ApiType.POST,
                Data = registrationRequestDto,
                Url = StaticDescriptions.AuthAPIBase + "/api/auth/AssignRole"
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            try
            {
                ResponseDto response = await _baseService.SendAsync(new RequestDto()
                {
                    ApiType = Static.StaticDescriptions.ApiType.POST,
                    Data = loginRequestDto,
                    Url = "https://localhost:7224/" + "api/AuthAPI/login"
                }, withBearer: false);

                LoginResponsedto loginResponse = JsonConvert.DeserializeObject<LoginResponsedto>(response.Result.ToString()) as LoginResponsedto;
                //set Token
                _tokenProvider.SetToken(loginResponse.Token);
                //Change auth state of app
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

                return response;

            }
            catch (Exception ex)
            {
                ResponseDto failure = new ResponseDto();
                failure.Message = ex.Message;
                failure.IsSuccess = false;
                return failure;

            }
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Static.StaticDescriptions.ApiType.POST,
                Data = registrationRequestDto,
                Url = StaticDescriptions.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> LogoutAsync()
        {
            try
            {
                ResponseDto response = new ResponseDto();
                //Clear token
                await _tokenProvider.ClearToken();

                //Change auth state of app
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();

                response.IsSuccess = true;
                response.Message = "The user was logged out successfully.";

                return response;

            }
            catch (Exception ex)
            {
                ResponseDto failure = new ResponseDto();
                failure.Message = ex.Message;
                failure.IsSuccess = false;
                return failure;

            }
        }
    }
}
