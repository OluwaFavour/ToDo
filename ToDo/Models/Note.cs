using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public enum Color
    {
        RED,
        BLUE,
        GREEN,
        YELLOW,
        WHITE
    }
    
    public class Note
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Details { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(250, ErrorMessage = "Title should not contain more than 250 characters")]
        public string Title { get; set; }
        public Color Color { get; set; }
        public string DateCreated { get; set; }

        public Note()
        {
            DateCreated = DateTime.UtcNow.ToString("MMM d, yyyy - h:mm tt");
        }
    }
}
