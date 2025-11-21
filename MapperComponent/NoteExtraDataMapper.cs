using ApplicationComponent;
using ApplicationComponent.DTOs;
using RepositoryComponent.ExtraData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperComponent
{
    public class NoteExtraDataMapper : IMapper<NoteDTO, NoteExtraData>
    {
        public NoteExtraData Map(NoteDTO dto)
        {
            return new NoteExtraData()
            {
                Color = dto.Color
            };
        }
    }
}
