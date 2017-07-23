using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BllLayer.Automapper.Profiles;

namespace BllLayer.Automapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AlbumMappingProfile>();
                x.AddProfile<TrackMappingProfile>();
            });
        }
    }
}
