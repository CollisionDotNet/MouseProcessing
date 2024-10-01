namespace MouseProcessing.Infrastructure.Entities
{
    public class CursorInfoEntity
    {
        public Guid Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public DateTime Time { get; set; }
        public CursorInfoEntity(Guid id, int x, int y, DateTime time)
        {
            Id = id;
            X = x;
            Y = y;
            Time = time;
        }
    }
}
