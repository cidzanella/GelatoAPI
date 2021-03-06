using System.ComponentModel.DataAnnotations;

namespace GelatoAPI.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

    }
}
