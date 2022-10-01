using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAPIHouses.Dtos
{
    public class HouseDto
    {
        public int Id { get; set; }
        [Required]
        public string DoorNum { get; set; } = string.Empty;
        [Required]
        public string Address1 { get; set; } = string.Empty;
        [Required]
        public string Address2 { get; set; } = string.Empty;
        [Required]
        public string Address3 { get; set; } = string.Empty;
        public string Address4 { get; set; } = string.Empty;
        public string Address5 { get; set; } = string.Empty;
        public string Address6 { get; set; } = string.Empty;
        [Precision(precision: 10, scale: 2)]
        public decimal Rent { get; set; }
        public string Premises { get; set; } = string.Empty;
        public string HouseNote { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}