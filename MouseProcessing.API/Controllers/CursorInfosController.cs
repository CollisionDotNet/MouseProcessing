using Microsoft.AspNetCore.Mvc;
using MouseProcessing.Domain.Abstractions;
using MouseProcessing.Domain.Entities;
using MouseProcessing.Domain.BaseTypes;
using MouseProcessing.API.Dtos;

namespace MouseProcessing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CursorInfosController : ControllerBase
    {
        private readonly ICursorInfoService _service;
        private readonly IMapper<CursorInfo, CursorInfoCreateDto> _cursorInfoCreateDtoMapper;
        public CursorInfosController(ICursorInfoService service, IMapper<CursorInfo, CursorInfoCreateDto> cursorInfoCreateDtoMapper)
        {
            _service = service;
            _cursorInfoCreateDtoMapper = cursorInfoCreateDtoMapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CursorInfoCreateDto cursorInfoToCreateRequest)
        {
            Guid id = await _service.CreateCursorInfoAsync(_cursorInfoCreateDtoMapper.Map(cursorInfoToCreateRequest));
            return Ok(id);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRange([FromBody] IEnumerable<CursorInfoCreateDto> cursorInfosToCreateRequest)
        {
            IEnumerable<Guid> ids = await _service.CreateCursorInfoRangeAsync(cursorInfosToCreateRequest.Select(_cursorInfoCreateDtoMapper.Map));
            return Ok(ids);
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CursorInfoGetDto request)
        {
            CursorInfo? cursorInfo = await _service.GetCursorInfoAsync(request.Id);
            return Ok(cursorInfo);
        }
        [HttpGet]
        public async Task<IActionResult> GetRange([FromQuery] IEnumerable<CursorInfoGetDto> cursorInfosToGetRequest)
        {
            IEnumerable<CursorInfo?> cursorInfos = await _service.GetCursorInfoRangeAsync(cursorInfosToGetRequest.Select(dto => dto.Id));
            return Ok(cursorInfos);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CursorInfo> allCursorInfos = await _service.GetAllCursorInfosAsync();
            return Ok(allCursorInfos);
        }
    }
}
