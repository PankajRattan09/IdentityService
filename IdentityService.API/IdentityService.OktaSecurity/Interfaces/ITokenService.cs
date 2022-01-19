namespace IdentityService.OktaSecurity.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken();
    }
}
