using System.ComponentModel.DataAnnotations;

namespace ChatProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required(ErrorMessage = "Lütfen e-mail adresinizi giriniz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen e-mail adresinizi giriniz.")]
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
