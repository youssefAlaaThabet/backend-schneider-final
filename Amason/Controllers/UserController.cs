using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amason.Data;
using Amason.help.dtos;
using Amason.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Amason.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly DemoContext _context;
        public UserController(IMapper mapper, DemoContext context)
        {
            _mapper = mapper;
            _context = context;
        }
       

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                 await _context.user.AddAsync(user);
                await _context.SaveChangesAsync();
                var userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);


            }
            catch (Exception)
            {
                return StatusCode(404, new { Error = " an error occured while Adding the User " });
            }

        }

    }
}
