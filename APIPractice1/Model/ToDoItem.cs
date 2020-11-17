using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Content { get; set; }

        [Required]
        public DateTime DateTimeCreated { get; set; }

        [Required]
        public bool Done { get; set; }
    }
}