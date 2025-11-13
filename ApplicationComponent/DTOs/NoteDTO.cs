using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationComponent.DTOs
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Message { get; set; }
        public string? Color { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
