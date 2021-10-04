using System.ComponentModel.DataAnnotations;

namespace GelatoAPI.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength =4)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false; 
    }
}
