using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SecuredSqlSample.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileDbContext _context;

        public ProfileController(ProfileDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Profile profile)
        {
            _context.Add(profile);
            await _context.SaveChangesAsync();
            return Created(profile.Id.ToString(), profile);
        }

        [HttpGet]
        public async Task<ICollection<Profile>> Get()
        {
            return await _context.Profiles.ToListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Profile> Get(int id)
        {
            return await _context.Profiles.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}