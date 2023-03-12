using MapApp.Domain.Dto.Request;
using MapApp.Domain.Dto.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressMapController : ControllerBase
    {
        public AddressMapController()
        {

        }

        [HttpPost("coords")]
        public async Task<IActionResult> Get(AddressRequestDto postData) {
            var data = new AddressMapResultsDto();
            return Ok(data);
        }
    }
}
