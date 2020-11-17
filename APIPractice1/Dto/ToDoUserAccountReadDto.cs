using System.ComponentModel.DataAnnotations;

namespace Dto
{
    public class ToDoUserAccountReadDto
    {
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