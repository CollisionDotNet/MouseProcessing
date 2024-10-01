using MouseProcessing.Domain.Entities;

namespace MouseProcessing.Domain.Abstractions
{
    public interface ICursorInfoRepository
    {
        public Task<Guid> CreateAsync(CursorInfo cursorInfo);
        public Task<IEnumerable<Guid>> CreateRangeAsync(IEnumerable<CursorInfo> cursorInfos);
        public Task<CursorInfo?> GetAsync(Guid id);
        public Task<IEnumerable<CursorInfo?>> GetRangeAsync(IEnumerable<Guid> ids);
        public Task<IEnumerable<CursorInfo>> GetAllAsync();
    }
}
