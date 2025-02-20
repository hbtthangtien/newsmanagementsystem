using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class LoginModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8,ErrorMessage ="Password must be at least 8 character")]
        [Required()]
        public string Password { get; set; }

        public LoginModel()
        {
        }
    }
}
