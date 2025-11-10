using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryComponent.Models
{
    public class NoteModel
    {
        public int Id  { get; set; }
        public int ItemId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Color { get; set; }
        public ItemModel Item { get; set; }
    }
}
