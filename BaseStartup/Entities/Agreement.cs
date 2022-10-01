using Microsoft.EntityFrameworkCore;

namespace WebAPIHouses.Entities
{
    public class Agreement
    {
        public int Id { get; set; }
        public DateTime? DateAgreement { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Landlord> Landlords { get; set; } = new();
        public List<Tenant> Tenants { get; set; } = new();
        public int HouseId { get; set; }
        public House? House { get; set; }
        [Precision(precision: 10, scale: 2)]
        public decimal Rent { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}