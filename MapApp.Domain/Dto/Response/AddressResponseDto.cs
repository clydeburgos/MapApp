﻿namespace MapApp.Domain.Dto.Response
{
    public class AddressResponseDto
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Title { get; set; }
    }

    public class AddressMapResultsDto {
        public IEnumerable<AddressResponseDto> Results { get; set; }
    }
}
