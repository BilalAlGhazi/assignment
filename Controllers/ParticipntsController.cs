using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Activity.API.Data;
using Activity.API.Models;
using Activity.API.Dtos;
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

        // GET api/participants
        [HttpGet]
        public async Task<IActionResult> GetParticipants()
        {
            var values = await _context.Participants.ToListAsync();

            return Ok(values);
        }

        // POST api/participants
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ParticipantDto participantObj)
        {
            var participantToAdd = new Participant{
                FirstName = participantObj.FirstName,
                LastName = participantObj.LastName,
                Email = participantObj.Email,
                Activity = participantObj.Activity,
                Comments = participantObj.Comments
            };
            await _context.Participants.AddAsync(participantToAdd);
            await _context.SaveChangesAsync();
            // Done
            return StatusCode(201);
        }
    }
}
