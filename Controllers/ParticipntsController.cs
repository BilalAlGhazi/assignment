using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Activity.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Activity.API.Controllers
{
    [Route("api/[controller]")]
    public class ParticipantsController : Controller
    {
        private readonly DataContext _context;
        public ParticipantsController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetParticipants()
        {
            var values = await _context.Participants.ToListAsync();

            return Ok(values);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
