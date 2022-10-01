using WebAPIHouses.Entities;

namespace WebAPIHouses.Dtos
{
    public class AgreementDto
    {
        public int Id { get; set; }
        public string? KeyNav { get; set; }
        public DateTime? DateAgreement { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<LandlordDto> Landlords { get; set; } = new();
        public List<TenantDto> Tenants { get; set; } = new();
        public int HouseId { get; set; }
        public HouseDto? House { get; set; }
        public decimal Rent { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
    public class AgreementToReturnDto
    {
        public int Id { get; set; }
        public string KeyNav { get; set; } = string.Empty;
        public DateTime? DateAgreement { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<LandlordDto> Landlords { get; set; } = new();
        public List<TenantDto> Tenants { get; set; } = new();
        //public int HouseId { get; set; }

        public string Address { get; set; } = string.Empty;
        public decimal Rent { get; set; }
        public string Premises { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }

}
