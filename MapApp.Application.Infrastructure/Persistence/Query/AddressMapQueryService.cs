using Dapper;
using MapApp.Application.Contracts.Persistence.Query;
using MapApp.Dapper;
using MapApp.Domain.Dto.Request;
using MapApp.Domain.Dto.Response;


namespace MapApp.Infrastructure.Persistence.Query
{
    public class AddressMapQueryService : IAddressMapQueryService
    {
        private readonly ISQLDapperBase database;
        public AddressMapQueryService(ISQLDapperBase database)
        {
            this.database = database;
        }
        public async Task<IEnumerable<AddressResponseDto>> GetAddressMapQuery(AddressRequestDto requestDto)
        {
            var param = new DynamicParameters();
            string query = $"SELECT POINT_X AS Longitude, POINT_Y AS Latitude, " +
                $" STREET_NUM + ' ' + STREET_NAME + ' ' + MUNICIPALITY + ', ' + STATE + ', ' + ZIPCODE AS Title FROM AddressPoints" +
                $" WITH (NOLOCK) WHERE ((POINT_Y BETWEEN @SPOINTY AND @NPOINTY) AND (POINT_X BETWEEN @SPOINTX AND @NPOINTX ))";

            if (!string.IsNullOrEmpty(requestDto.Search)) {
                //for some reason dapper didnt worked with params
                //so im temporarily using this approach
                query += $" AND (STREET_NAME LIKE '%{requestDto.Search}%' OR MUNICIPALITY LIKE '%{requestDto.Search}%'" +
                    $" OR State LIKE '%{requestDto.Search}%' OR ZIPCODE LIKE '%{requestDto.Search}%')";
            }
            param.Add("@NPOINTX", requestDto.NorthEast.Lng);
            param.Add("@SPOINTX", requestDto.SouthWest.Lng);

            param.Add("@NPOINTY", requestDto.NorthEast.Lat);
            param.Add("@SPOINTY", requestDto.SouthWest.Lat);

            return await database.QueryAsListAsync<AddressResponseDto>(query, param, System.Data.CommandType.Text);
        }
    }
}
