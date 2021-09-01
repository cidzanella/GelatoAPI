using System.ComponentModel.DataAnnotations;

namespace GelatoAPI.DTOs
{
    // only Password and IsAdmin attributes may be updated
    public class UserUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
