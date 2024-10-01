using MouseProcessing.Domain.Entities;

namespace MouseProcessing.Domain.Abstractions
{
    public interface ICursorInfoService
    {
        public Task<Guid> CreateCursorInfoAsync(CursorInfo cursorInfo);
        public Task<IEnumerable<Guid>> CreateCursorInfoRangeAsync(IEnumerable<CursorInfo> cursorInfos);
        public Task<CursorInfo?> GetCursorInfoAsync(Guid id);
        public Task<IEnumerable<CursorInfo?>> GetCursorInfoRangeAsync(IEnumerable<Guid> ids);
        public Task<IEnumerable<CursorInfo>> GetAllCursorInfosAsync();
    }
}
