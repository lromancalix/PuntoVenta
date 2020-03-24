using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DTO;
using Entities.Request;
using Entities.Response;

namespace PV.Api.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<RequestMarca, MarcaDTO>().ReverseMap();
            CreateMap<MarcaDTO, MarcaResponse>().ReverseMap();
            CreateMap<DetallesMarcaResponse, MarcaDTO>().ReverseMap();


            CreateMap<DepartamentoRequest, DepartamentoDTO>().ReverseMap();
            CreateMap<DepartamentoDTO, DepartamentoResponse>().ReverseMap();

            CreateMap<TiendaRequest, TiendaDTO>().ReverseMap();
            CreateMap<TiendaDTO, TiendaResponse>().ReverseMap();



        }

    }
}
