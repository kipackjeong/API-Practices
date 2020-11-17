using System.ComponentModel.DataAnnotations;

namespace APIPractice2.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
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