using System.ComponentModel.DataAnnotations;

namespace Supplychain_Core.Requests
{
    public class AuthModelRequest
    {
        [Required,MaxLength(50)]
        public string UserName { get; set; }
        [Required, MaxLength(50),EmailAddress(ErrorMessage ="Invaild Mail")]
        public string Email { get; set; }
        [Required, MaxLength(10)]
        public string Password { get; set; }
    }
}
