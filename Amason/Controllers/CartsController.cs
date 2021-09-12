using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amason.Data;
using Amason.help.dtos;
using Amason.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Amason.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DemoContext _context;
        public CartsController(IMapper mapper, DemoContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        // GET: api/<CartsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var carts = await _context.cart.ToListAsync();
                 return Ok(_mapper.Map<List<CartDto>>(carts));

            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = " an error happened while getting all Carts" });
            }
        }
       

        //// POST api/<CartsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cart cart)
        {
            try
            {
                await _context.cart.AddAsync(cart);
                await _context.SaveChangesAsync();
                var cartDto = _mapper.Map<CartDto>(cart);
                return Ok(cartDto);

            }
            catch (Exception ex)
            {
                return StatusCode(404, new { Error = " an error occured while Adding the Cart " });
            }

        }

        // PUT api/<CartsController>/5
        [HttpPut()]
        public async Task<IActionResult> Put( [FromBody] Cart cart)
        {
            try
            {
                var Localcart = await _context.cart.SingleOrDefaultAsync(st => st.ProductId == cart.ProductId);
                if (cart.Number > 0)
                {
                    Localcart.Number = cart.Number;
                }
                else
                {
                    _context.Remove(Localcart);
                }
                await _context.SaveChangesAsync();

                var cartDto = _mapper.Map<CartDto>(cart);
                return Ok(cartDto);

            }
            catch (Exception)
            {
                return StatusCode(400, new { Error = " an error occured while Updating Cart with id="  });
            }



        }
        // DELETE api/<Carts>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cart = await _context.cart.SingleOrDefaultAsync(st => st.Id == id);
                _context.Remove(cart);
                await _context.SaveChangesAsync();
                var cartDto = _mapper.Map<CartDto>(cart);
                return Ok(cartDto);

            }
            catch (Exception)
            {
                return StatusCode(404, new { Error = " an error occured while deleting Cart with id=" + id });
            }


        }

    }
}
