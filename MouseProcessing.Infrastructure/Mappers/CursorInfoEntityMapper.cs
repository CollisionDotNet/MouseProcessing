using MouseProcessing.Domain.BaseTypes;
using MouseProcessing.Domain.Entities;
using MouseProcessing.Infrastructure.Entities;

namespace MouseProcessing.Infrastructure.Mappers
{
    public class CursorInfoEntityMapper : IMapper<CursorInfo, CursorInfoEntity>
    {
        public CursorInfo Map(CursorInfoEntity obj)
        {
            return new CursorInfo(obj.Id, obj.X, obj.Y, obj.Time);
        }

        public CursorInfoEntity Map(CursorInfo obj)
        {
            return new CursorInfoEntity(obj.Id, obj.X, obj.Y, obj.Time);
        }
    }
}
