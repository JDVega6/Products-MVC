using AutoMapper;
using MVC_Challenge.Data.Models;
using MVC_Challenge.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Challenge.Domain.Profiles
{
    public class ProductsProfiles : Profile
    {
        public ProductsProfiles()
        {
            //GET - VIEW MODEL
            CreateMap<Products, ProductsViewModel>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (EntityTypeOption)src.Type))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status ? EntityStatus.Activo : EntityStatus.Activo));

            //POST
            CreateMap<ProductCreateDto, Products>()
                .ForMember(dest => dest.Type, opt =>opt.MapFrom(src => (int)src.Type))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status == EntityStatus.Activo));

            //PUT
            CreateMap<ProductUpdateDto, Products>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status == EntityStatus.Activo));


        }
    }
}
