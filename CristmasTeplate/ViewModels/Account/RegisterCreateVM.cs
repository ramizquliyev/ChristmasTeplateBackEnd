using System.ComponentModel.DataAnnotations;

namespace CristmasTeplate.ViewModels.Account
{
    public class RegisterCreateVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfrimPassword { get; set; }
    }
}
