using System.ComponentModel.DataAnnotations;

namespace APIPractice2.Dto
{
    public class CustomerCreatedDto
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(30)]
        public string EmailAddress { get; set; }
    }
}