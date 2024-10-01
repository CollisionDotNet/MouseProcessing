using Microsoft.EntityFrameworkCore;
using MouseProcessing.Domain.Abstractions;
using MouseProcessing.Domain.Entities;
using MouseProcessing.Infrastructure.Entities;
using MouseProcessing.Infrastructure.Mappers;

namespace MouseProcessing.Infrastructure.Repositories
{
    public class EFCursorInfoRepository : ICursorInfoRepository
    {
        private readonly CursorDBContext _context;
        private readonly CursorInfoEntityMapper _mapper;
        public EFCursorInfoRepository(CursorDBContext context, CursorInfoEntityMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> CreateAsync(CursorInfo cursorInfo)
        {
            CursorInfoEntity toAdd = _mapper.Map(cursorInfo);
            await _context.CursorInfos.AddAsync(toAdd);
            await _context.SaveChangesAsync();
            return toAdd.Id;
        }

        public async Task<IEnumerable<Guid>> CreateRangeAsync(IEnumerable<CursorInfo> cursorInfos)
        {
            IEnumerable<CursorInfoEntity> toAdd = cursorInfos.Select(_mapper.Map);
            await _context.CursorInfos.AddRangeAsync(toAdd);
            await _context.SaveChangesAsync();
            return toAdd.Select(e => e.Id);
        }

        public async Task<IEnumerable<CursorInfo>> GetAllAsync()
        {
            return await 
                _context.CursorInfos
                .AsNoTracking()
                .Select(e => _mapper.Map(e))
                .ToListAsync();
        }

        public async Task<CursorInfo?> GetAsync(Guid id)
        {
            CursorInfoEntity? toGet = await _context.CursorInfos.FindAsync(id);
            if (toGet == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map(toGet);
            }
        }

        public async Task<IEnumerable<CursorInfo?>> GetRangeAsync(IEnumerable<Guid> ids)
        {
            return await _context.CursorInfos
                .AsNoTracking()          
                .Select(e => ids.Contains(e.Id) ? _mapper.Map(e) : null)
                .ToListAsync();
        }
    }
}
