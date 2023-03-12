using MapApp.Domain.Dto.Request;
using MapApp.Domain.Dto.Response;

namespace MapApp.Application.Contracts.Persistence.Query
{
    public interface IAddressMapQueryService
    {
        Task<IEnumerable<AddressResponseDto>> GetAddressMapQuery(AddressRequestDto requestDto);
    }
}
