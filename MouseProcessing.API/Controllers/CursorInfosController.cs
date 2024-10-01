using Microsoft.AspNetCore.Mvc;
using MouseProcessing.Domain.Abstractions;
using MouseProcessing.Domain.Entities;
using MouseProcessing.API.Dtos;
using MouseProcessing.API.Mappers;

namespace MouseProcessing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ContactsController : ControllerBase
    {
        private readonly ICursorInfoService _service;
        public ContactsController(ICursorInfoService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CursorInfoCreateDto cursorInfoToCreateRequest)
        {
            CursorInfoCreateDtoMapper mapper = new CursorInfoCreateDtoMapper();
            Guid id = await _service.CreateCursorInfoAsync(mapper.Map(cursorInfoToCreateRequest));
            return Ok(id);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRange([FromBody] IEnumerable<CursorInfoCreateDto> cursorInfosToCreateRequest)
        {
            CursorInfoCreateDtoMapper mapper = new CursorInfoCreateDtoMapper();
            IEnumerable<Guid> ids = await _service.CreateCursorInfoRangeAsync(cursorInfosToCreateRequest.Select(mapper.Map));
            return Ok(ids);
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] CursorInfoGetDto request)
        {
            CursorInfo? cursorInfo = await _service.GetCursorInfoAsync(request.Id);
            return Ok(cursorInfo);
        }
        [HttpGet]
        public async Task<IActionResult> GetRange([FromBody] IEnumerable<CursorInfoGetDto> cursorInfosToGetRequest)
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
