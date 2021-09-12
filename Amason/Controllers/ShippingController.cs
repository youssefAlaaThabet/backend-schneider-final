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
    public class ShippingController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly DemoContext _context;
        public ShippingController(IMapper mapper, DemoContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        // POST api/<ShippingController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shipping shipping)
        {
            try
            {
                await _context.shipping.AddAsync(shipping);
                await _context.SaveChangesAsync();
                var shippingDto = _mapper.Map<ShippingDto>(shipping);
                return Ok(shippingDto);

            }
            catch (Exception ex)
            {
                return StatusCode(404, new { Error = " an error occured while Adding the shippment address " });
            }

        }



    }
}
