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
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DemoContext _context;
        public ProductsController(IMapper mapper, DemoContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        // GET: api/<ProductsController>
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _context.product.ToListAsync();
                return Ok(_mapper.Map<List<ProductDto>>(products));

            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = " an error happened while getting all Products" });
            }
        }


        //    // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try
            {
                await _context.product.AddAsync(product);
                await _context.SaveChangesAsync();
                var productDto = _mapper.Map<ProductDto>(product);
                return Ok(productDto);

            }
            catch (Exception ex)
            {
                return StatusCode(404, new { Error = " an error occured while Adding the Product " });
            }

        }

    }
}
