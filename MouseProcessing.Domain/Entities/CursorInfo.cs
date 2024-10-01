using MouseProcessing.Domain.BaseTypes;

namespace MouseProcessing.Domain.Entities
{
    public class CursorInfo : IEntity
    {
        public Guid Id { get; }
        public int X { get; }
        public int Y { get; }
        public DateTime Time { get; }
    }
}
