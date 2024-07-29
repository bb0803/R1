using R1.FrontEnd.Web.Services.Interfaces;
using R1.FrontEnd.Web.Static;
using Microsoft.Extensions.Http;
using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Diagnostics;
using Microsoft.AspNetCore.Components.Authorization;


namespace R1.FrontEnd.Web.Services.Implementations
{
    public class TokenProvider: ITokenProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;
        public TokenProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        }


        public async Task ClearToken()
        {
            await localStorage.RemoveItemAsync("R1_accessToken");
        }

        public async Task<string> GetToken()
        {
            var savedToken1 = await localStorage.GetItemAsync<string>("R1_accessToken");
            if (savedToken1 == null) { return null; }
            //var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken1);
            return savedToken1.ToString();
        }

        public void SetToken(string token)
        {
            localStorage.SetItemAsync<string>("R1_accessToken", token);

        }
    }
}
