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
    public class TrackMappingProfile : Profile
    {
        public TrackMappingProfile()
        {
            CreateMap<Track, TrackDto>()
               .ForMember(d => d.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(d => d.Name, opts => opts.MapFrom(src => src.Name))
               .ForMember(d => d.Artist, opts => opts.MapFrom(src => src.Artist))
               .ForMember(d => d.Duration, opts => opts.MapFrom(src => src.Duration))
               .ForMember(d => d.AlbumId, opts => opts.MapFrom(src => src.AlbumId));

            CreateMap<TrackDto, Track>()
               .ForMember(d => d.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(d => d.Name, opts => opts.MapFrom(src => src.Name))
               .ForMember(d => d.Artist, opts => opts.MapFrom(src => src.Artist))
               .ForMember(d => d.Duration, opts => opts.MapFrom(src => src.Duration))
               .ForMember(d => d.AlbumId, opts => opts.MapFrom(src => src.AlbumId));
        }
    }
}
