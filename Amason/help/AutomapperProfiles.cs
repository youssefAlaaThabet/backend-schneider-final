using Amason.help.dtos;
using Amason.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amason.help
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<Shipping, ShippingDto>().ReverseMap();



        }
    }
}
