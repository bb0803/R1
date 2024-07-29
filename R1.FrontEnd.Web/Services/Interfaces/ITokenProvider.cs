namespace R1.FrontEnd.Web.Services.Interfaces
{
    public interface ITokenProvider
    {
        void SetToken(string token);
        Task<string?> GetToken();
        Task ClearToken();
    }
}
