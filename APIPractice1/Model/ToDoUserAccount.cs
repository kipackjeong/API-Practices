using System.ComponentModel.DataAnnotations;

namespace AppPractice1.Model
{
    public class ToDoUserAccount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        
    }
}