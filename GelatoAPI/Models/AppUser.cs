using System.ComponentModel.DataAnnotations;

namespace GelatoAPI.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
