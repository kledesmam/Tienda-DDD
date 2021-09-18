using AutoMapper;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ParametroDetalle, ParametroDetalleDto>();
            CreateMap<ParametroDetalleDto, ParametroDetalle>();
        }
    }
}
