using MouseProcessing.Domain.Abstractions;
using MouseProcessing.Domain.Entities;

namespace MouseProcessing.Application.Services
{
    public class CursorInfoService : ICursorInfoService
    {
        private readonly ICursorInfoRepository _repository;
        public CursorInfoService(ICursorInfoRepository repository) 
        { 
            _repository = repository;
        }
        public async Task<Guid> CreateCursorInfoAsync(CursorInfo cursorInfo)
        {
            return await _repository.CreateAsync(cursorInfo);
        }

        public async Task<IEnumerable<Guid>> CreateCursorInfoRangeAsync(IEnumerable<CursorInfo> cursorInfos)
        {
            return await _repository.CreateRangeAsync(cursorInfos);
        }

        public async Task<IEnumerable<CursorInfo>> GetAllCursorInfosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CursorInfo?> GetCursorInfoAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<CursorInfo?>> GetCursorInfoRangeAsync(IEnumerable<Guid> ids)
        {
            return await _repository.GetRangeAsync(ids);
        }
    }
}
