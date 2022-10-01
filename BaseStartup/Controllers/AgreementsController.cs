using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseStartup.Data;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIHouses.Dtos;
using WebAPIHouses.Entities;
using WebAPIHouses.Json;

namespace WebAPIHouses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IHashids _hashids;
        private readonly IMapper _mapper;

        public AgreementsController(DataContext context, IHashids hashids, IMapper mapper)
        {
            _context = context;
            _hashids = hashids;
            _mapper = mapper;
        }

        // GET: api/Agreements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgreementToReturnDto>>> GetAgreements()
        {
          if (_context.Agreements == null)
          {
              return NotFound();
          }

          //var results = await _context
          //      .Agreements
          //      .Include(ten => ten.Tenants)
          //      .Include(l => l.Landlords)
          //      .Include(h => h.House)
          //      .ProjectTo<AgreementToReturnDto>(_mapper.ConfigurationProvider)
          //      .ToListAsync();

            //var results2 = await _context
            //   .Agreements.Select(ag => new AgreementDto
            //   {
            //       Id = ag.Id,
            //       KeyNav = _hashids.Encode(ag.Id),
            //       DateAgreement = ag.DateAgreement,
            //       StartDate = ag.StartDate,
            //       EndDate = ag.EndDate,
            //       Landlords = ag.Landlords
            //       .Select(lnd => new 
            //                   LandlordDto { 
            //                       Id = lnd.Id, 
            //                       Fullname = lnd.Fullname, 
            //                       Address = lnd.Address, 
            //                       Email = lnd.Email, 
            //                       MobileNumber= lnd.MobileNumber, 
            //                       PhotoUrl= lnd.PhotoUrl })
            //                   .ToList() ,
            //       Tenants = ag.Tenants
            //       .Select(ta => new 
            //                       TenantDto { 
            //                        Id= ta.Id,
            //                         FullName = ta.FullName,
            //                         Email = ta.Email,
            //                         MobileNumber = ta.MobileNumber
            //                       }).ToList() ,
            //       HouseId = ag.HouseId,
            //       House = new  HouseDto
            //                       {
            //                           Id = ag.House.Id,
            //                           Address1= ag.House.Address1,
            //                           Address2= ag.House.Address2,
            //                           Address3= ag.House.Address3,
            //                           Address4= ag.House.Address4,
            //                           Address5= ag.House.Address5,
            //                           Address6= ag.House.Address6,
            //       },
            //       Rent = ag.Rent})
            //   .ToListAsync();

            var results2 = await _context
               .Agreements.Select(ag => new AgreementToReturnDto
               {
                   Id = ag.Id,
                   KeyNav = _hashids.Encode(ag.Id),
                   DateAgreement = ag.DateAgreement,
                   StartDate = ag.StartDate,
                   EndDate = ag.EndDate,
                   Landlords = ag.Landlords.Select(lnd => new  LandlordDto { Id = lnd.Id, KeyNav= _hashids.Encode(lnd.Id), Fullname = lnd.Fullname, PhotoUrl = lnd.PhotoUrl}).ToList(),
                   Tenants = ag.Tenants.Select(ta => new TenantDto {Id = ta.Id, KeyNav = _hashids.Encode(ta.Id), FullName = ta.FullName}).ToList(),
                   Address = $"{ag.House!.Address1} {ag.House.Address2} {ag.House.Address3} {ag.House.Address4} {ag.House.Address5} {ag.House.Address6}",
                   Rent = ag.Rent
               })
               .ToListAsync();
            //var mappToDto = _mapper.Map<List<AgreementDto>>(results2);
            return results2;
        }

        // GET: api/Agreements/5
        [HttpGet("hashid/{id}")]
        public async Task<ActionResult<Agreement>> GetAgreement(string id)
        {
            int[] decodeId = _hashids.Decode(id);
            if (decodeId.Length == 0)
            {
                return NotFound();
            }
            if (_context.Agreements == null)
            {
                  return NotFound();
            }
            var agreement = await _context.Agreements.FindAsync(decodeId[0]);

            if (agreement == null)
            {
                return NotFound();
            }

            return agreement;
        }

        // PUT: api/Agreements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgreement(int id, Agreement agreement)
        {
            if (id != agreement.Id)
            {
                return BadRequest();
            }

            _context.Entry(agreement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgreementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Agreements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agreement>> PostAgreement(Agreement agreement)
        {
          if (_context.Agreements == null)
          {
              return Problem("Entity set 'DataContext.Agreements'  is null.");
          }
            _context.Agreements.Add(agreement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgreement", new { id = agreement.Id }, agreement);
        }

        // DELETE: api/Agreements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgreement(int id)
        {
            if (_context.Agreements == null)
            {
                return NotFound();
            }
            var agreement = await _context.Agreements.FindAsync(id);
            if (agreement == null)
            {
                return NotFound();
            }

            _context.Agreements.Remove(agreement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgreementExists(int id)
        {
            return (_context.Agreements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
