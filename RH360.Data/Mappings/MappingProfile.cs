using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RH360.Data.DTO;
using RH360.Domain.Entities;

namespace RH360.Data.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
        }
    }
}
