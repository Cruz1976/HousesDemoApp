using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAPIHouses.Entities;

public class House
{
    public int Id { get; set; }
    [Required]
    public string DoorNum { get; set; } = String.Empty;
    [Required]
    public string Address1 { get; set; }= String.Empty;
    [Required]
    public string Address2 { get; set; } =String.Empty;
    [Required]
    public string Address3 { get; set; }= String.Empty ;
    public string Address4 { get; set; } = String.Empty;
    public string Address5 { get; set; } = String.Empty;
    public string Address6 { get; set; } = String.Empty;
    [Precision(precision: 10, scale: 2)]
    public decimal Rent { get; set; }
    public string Premises { get; set; } = String.Empty;
    public string HouseNote { get; set; } = String.Empty;
    public string UserId { get; set; } = string.Empty;
}
