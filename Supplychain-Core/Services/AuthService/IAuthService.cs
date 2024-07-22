using Supplychain_Core.Requests;
using Supplychain_Core.Response;

namespace Supplychain_Core.Services.AuthService
{
    public  interface IAuthService
    {
        Task<AuthModelResponse> RegisterAsync(AuthModelRequest request);
    }
}
