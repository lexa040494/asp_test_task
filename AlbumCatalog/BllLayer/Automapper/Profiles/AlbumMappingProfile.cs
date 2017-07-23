using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Model;
using ViewModel.Models;

namespace BllLayer.Automapper.Profiles
{
    public class AlbumMappingProfile : Profile
    {
        public AlbumMappingProfile()
        {
            CreateMap<Album, AlbumDto>()
               .ForMember(d => d.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(d => d.Name, opts => opts.MapFrom(src => src.Name))
               .ForMember(d => d.Year, opts => opts.MapFrom(src => src.Year));

            CreateMap<AlbumDto, Album>()
               .ForMember(d => d.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(d => d.Name, opts => opts.MapFrom(src => src.Name))
               .ForMember(d => d.Year, opts => opts.MapFrom(src => src.Year));
        }
    }
}
