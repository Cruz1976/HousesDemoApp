using System.ComponentModel.DataAnnotations;

namespace WebAPIHouses.Entities
{
    public class Tenant
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string MobileNumber { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } =  string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string TenantNote { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;

    }
}