using Microsoft.AspNetCore.Identity;

namespace Supplychain_Core.Response
{
    public class AuthModelResponse
    {
        public AuthModelResponse(bool isSuccess , string message)
        {
            IsAuthenticated = isSuccess;
            Message = message;
        }
        public AuthModelResponse(bool isSuccess ,string userName , string email  ,  string token , DateTime date) 
        {
            IsAuthenticated=isSuccess;
            Username = userName;
            Email = email;
            Token = token;
            ExpiresAt = date;
        }  
        public bool IsAuthenticated { get; set; }
        public string Message {  get; set; }
        public string Username { get; set; }
        public string Email {  get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
