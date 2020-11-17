using System;
using System.ComponentModel.DataAnnotations;

namespace APIPractice.Model
{
    public class ToDoDate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        public DateTime DateCreated {get; set;}
        
        [Required]
        public int NumberOfDone { get; set; }
        
        [Required]
        public int NumberOfNotDone{get;set;}
    }
}