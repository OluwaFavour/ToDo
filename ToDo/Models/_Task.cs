using System;
using System.Collections.Generic;
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
    
    public class _Task
    {
        public int ID { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public Color Color { get; set; }
        public string DateCreated { get; set; }

        public _Task()
        {
            DateCreated = DateTime.UtcNow.ToString("MMM d, yyyy - h:mm tt");
        }
    }
}
