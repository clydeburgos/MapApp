namespace MapApp.Domain.Dto.Request
{
    public class AddressRequestDto
    {
        public decimal Zoom { get; set; }
        public string Search { get; set; }
        public NorthEast NorthEast { get; set; }
        public SouthWest SouthWest { get; set; }
    }

    public class NorthEast {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
    }

    public class SouthWest : NorthEast
    { 
    }
}
