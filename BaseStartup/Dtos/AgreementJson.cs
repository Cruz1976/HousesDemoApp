namespace WebAPIHouses.Json;

public class AgreementJson
{

    public string? DateAgreement { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public Landlord[]? Landlords { get; set; }
    public Tenant[]? Tenants { get; set; }
    public House? House { get; set; }
    public float? Rent { get; set; }

   

}
public class House
{
    public int DoorNum { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
    public string? Address4 { get; set; }
    public string? Address5 { get; set; }
    public string? Address6 { get; set; }
    public string? Premises { get; set; }
    public string? HouseNote { get; set; }
}

public class Landlord
{
    public string? Fullname { get; set; }
    public string? Addres1 { get; set; }
    public string? Email { get; set; }
    public string? MobileNumber { get; set; }
    public string? ContactNumber { get; set; }
    public string? PhotoUrl { get; set; }
    public string? LandlordNote { get; set; }
}

public class Tenant
{
    public string? TenantName { get; set; }
    public string? MobileNumber { get; set; }
    public string? ContactNumber { get; set; }
    public string? Email { get; set; }
    public string? PhotoUrl { get; set; }
    public string? TenantNote { get; set; }
}
