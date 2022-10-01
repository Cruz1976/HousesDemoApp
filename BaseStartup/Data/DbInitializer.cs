using BaseStartup.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using WebAPIHouses.Dtos;
using WebAPIHouses.Entities;
using WebAPIHouses.Json;
using HouseEntity = WebAPIHouses.Entities.House;

namespace BaseStartup.Data;

public static class DbInitializer
{
    public static async Task Initialize(DataContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ILoggerFactory loggerFactory)
    {
        try
        {
            using (var tranaction = context.Database.BeginTransaction())
            {
                if (!roleManager.Roles.Any())
                {
                    var roles = new List<IdentityRole>
                    {
                        new IdentityRole {Name = "Member", },
                        new IdentityRole {Name = "Admin"},
                        new IdentityRole {Name = "Manager"},
                    };
                    foreach (var role in roles)
                    {
                        await roleManager.CreateAsync(role);
                    }
                }
                if (!userManager.Users.Any())
                {
                    var user = new AppUser
                    {
                        UserName = "user@me.com",
                        Email = "user@me.com"
                    };

                    await userManager.CreateAsync(user, "Pa55w0rd!");
                    await userManager.AddToRoleAsync(user, "Member");

                    var admin = new AppUser
                    {
                        UserName = "admin",
                        Email = "admin@test.com"
                    };

                    await userManager.CreateAsync(admin, "Pa55w0rd!");
                    await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
                    await context.SaveChangesAsync();




                    
                }
                if (!context.Agreements.Any())
                {
                    var agreementData = await File.ReadAllTextAsync("Data/Agreements.json");
                    var agreements = JsonSerializer.Deserialize<List<AgreementJson>>(agreementData);
                    if (agreements == null) return;
                    foreach (var agreement in agreements)
                    {
                        Console.WriteLine(agreement);
                        Console.WriteLine(DateTime.Parse(agreement.DateAgreement!));
                        var agLandlords = new List<WebAPIHouses.Entities.Landlord>();
                        var agTenats = new List<WebAPIHouses.Entities.Tenant>();

                        foreach (var landlord  in agreement.Landlords!)
                        {
                            var _landlord = new WebAPIHouses.Entities.Landlord()
                            {
                                Address = landlord.Addres1!,
                                Fullname = landlord.Fullname!,
                                ContactNumber = landlord.ContactNumber!,
                                Email = landlord.Email!,
                                MobileNumber = landlord.MobileNumber!,
                                LandlordNote = landlord.LandlordNote!,
                                PhotoUrl = landlord.PhotoUrl!,
                            };
                            context.Landlords.Add(_landlord);
                            agLandlords.Add(_landlord);
                        }
                        foreach (var tenant in agreement.Tenants!)
                        {
                            var _tenant = new WebAPIHouses.Entities.Tenant()
                            {
                                FullName = tenant.TenantName!,
                                ContactNumber = tenant.ContactNumber!,
                                Email = tenant.Email!,
                                MobileNumber = tenant.MobileNumber!,
                                TenantNote = tenant.TenantNote!,
                                PhotoUrl = tenant.PhotoUrl!,
                            };
                            context.Tenants.Add(_tenant);
                            agTenats.Add(_tenant);
                        }
                        var house = new HouseEntity()
                        {
                            DoorNum = agreement.House!.DoorNum.ToString(),
                            Address1 = agreement.House.Address1!,
                            Address2 = agreement.House.Address2!,
                            Address3 = agreement.House.Address3!,
                            Address4 = agreement.House.Address4!,
                            Address5 = agreement.House.Address5!,
                            Address6 = agreement.House.Address6!,
                            Premises = agreement.House.Premises!,
                            Rent = (decimal)agreement.Rent!,
                            HouseNote =  agreement.House.HouseNote!
                        };
                        context.Add(house);
                        

                        var _agreement = new Agreement
                        {
                            DateAgreement = DateTime.Parse(agreement.DateAgreement!),
                            StartDate = DateTime.Parse(agreement.StartDate!),
                            EndDate = DateTime.Parse(agreement.EndDate!),
                            Landlords = agLandlords,
                            Tenants = agTenats,
                            House = house,
                            Rent = (decimal)agreement.Rent
                        };
                        context.Agreements.Add(_agreement);
                    }
                  await context.SaveChangesAsync();
                }
                tranaction.Commit();
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
}