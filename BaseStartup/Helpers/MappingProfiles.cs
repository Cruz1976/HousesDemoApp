using AutoMapper;
using BaseStartup.Dtos;
using BaseStartup.Entities;
using CloudinaryDotNet;
using HashidsNet;
using Microsoft.EntityFrameworkCore;
using WebAPIHouses.Dtos;
using WebAPIHouses.Entities;

namespace BaseStartup.Helpers
{
    public class MappingProfiles : Profile
    {
       // private readonly IHashids _hashids;

        public MappingProfiles()
        {
            //_hashids = hashids;
            //  CreateMap<JobSelect, JobSelectDockDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.JobName)).ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
           CreateMap<Agreement, AgreementToReturnDto>()
                .ForMember(dest => dest.KeyNav, opt => opt.MapFrom<AgreementIHashidsResolver>());
          //CreateMap<Agreement, AgreementDto>().ReverseMap();

           //CreateMap<Agreement, AgreementDto>().ConvertUsing<AgreementConverter>();
           CreateMap<House, HouseDto>().ReverseMap();
           CreateMap<Landlord, LandlordDto>().ReverseMap();
           CreateMap<Tenant, TenantDto>().ReverseMap();
            
        }
        public class AgreementConverter : ITypeConverter<Agreement, AgreementDto>
        {
            private readonly IHashids _hashids;
   

            public AgreementConverter(IHashids hashids)
            {
                _hashids = hashids;
            }
            public AgreementDto Convert(Agreement source, AgreementDto destination, ResolutionContext context)
            {
                
               // destination.KeyNav = _hashids.Encode(source.Id);
                
               // return destination;

                var dto = new AgreementDto
                {
                    Id = source.Id,
                    KeyNav = _hashids.Encode(source.Id),
                    DateAgreement = source.DateAgreement,
                    StartDate = source.StartDate,
                    EndDate = source.EndDate,
                    // Landlords = context.Mapper.Map<List<LandlordDto>>(source.Landlords),
                    // Tenants = context.Mapper.Map<List<TenantDto>>(source.Tenants),
                    HouseId = source.HouseId,
                    //House = context.Mapper.Map<HouseDto>(source.Tenants),
                    Rent = source.Rent
                };
               // var src = context.Mapper.Map .SourceValue as App;
                Console.WriteLine(dto);
                //Console.WriteLine(context.SourceValue);
                return dto;

            }
        }
        public class AgreementIHashidsResolver : IValueResolver<Agreement, AgreementToReturnDto, string>
        {
            private IHashids _hashids;
            public AgreementIHashidsResolver(IHashids hashids)
            {
                _hashids = hashids;
            }
            
            public string Resolve(Agreement source, AgreementToReturnDto destination, string destMember, ResolutionContext context)
            {
                //if(string.IsNullOrEmpty(source.Id.ToString()))
                //{
                    return _hashids.Encode(source.Id);
               // }
 
            }
        }
    }
}
