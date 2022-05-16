using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Travel.Data.Contexts;
using Travel.Domain.Entities;

namespace Travel.WebApi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class TourPackagesController : ControllerBase {
        private readonly TravelDbContext _context;

        public TourPackagesController(TravelDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(_context.TourPackages);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TourPackagesController tourPackage) {
            await _context.TourPackages.AddAsync(tourPackage);
            await _context.SaveChangesAsync();

            return Ok(tourPackage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var tourPackage = await _context.TourPackages.SingleOrDefaultAsync(tp => tp.id == id);

            if (tourPackage == null) {
                return NotFound();
            }

            _context.TourPackages.Remove(tourPackage);
            await _context._SaveChangesAsync();

            return Ok(tourPackage);
        }
    }
}