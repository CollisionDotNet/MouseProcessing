using MouseProcessing.API.Dtos;
using MouseProcessing.Domain.BaseTypes;
using MouseProcessing.Domain.Entities;

namespace MouseProcessing.API.Mappers
{
    public class CursorInfoCreateDtoMapper : IMapper<CursorInfo, CursorInfoCreateDto>
    {
        public CursorInfo Map(CursorInfoCreateDto obj)
        {
            return new CursorInfo(Guid.NewGuid(), obj.X, obj.Y, obj.Time);
        }

        public CursorInfoCreateDto Map(CursorInfo obj)
        {
            return new CursorInfoCreateDto(obj.X, obj.Y, obj.Time);
        }
    }
}
