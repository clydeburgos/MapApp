using MapApp.Application.Contracts.Persistence.Query;
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
        private readonly IAddressMapQueryService addressQueryService;
        public AddressMapController(IAddressMapQueryService addressQueryService)
        {
            this.addressQueryService = addressQueryService;
        }

        [HttpPost("coords")]
        public async Task<IActionResult> Get(AddressRequestDto postData) {
            var data = await addressQueryService.GetAddressMapQuery(postData);
            return Ok(new { results = data });
        }
    }
}
