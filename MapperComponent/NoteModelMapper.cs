using ApplicationComponent;
using ApplicationComponent.DTOs;
using RepositoryComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperComponent
{
    public class NoteModelMapper : IMapper<NoteDTO, NoteModel>
    {
        public NoteModel Map(NoteDTO dto)
        {
            return new NoteModel
            {
                Id = dto.Id,
                ItemId = dto.ItemId,
                Message = dto.Message,
                CreatedAt = DateTime.Now,
                Color = dto.Color
            };
        }
    }
}
