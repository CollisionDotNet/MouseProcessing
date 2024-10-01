using MouseProcessing.Domain.BaseTypes;

namespace MouseProcessing.Domain.Entities
{
    public class CursorInfo : IEntity
    {
        public Guid Id { get; }
        public int X { get; }
        public int Y { get; }
        public DateTime Time { get; }
        public CursorInfo(Guid id,  int x, int y, DateTime time)
        {
            Id = id;
            X = x;
            Y = y;
            Time = time;
        }
    }
}
