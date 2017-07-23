using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    [DataContract]
    public class AlbumDto
    {
        [DataMember]
        public decimal Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int  Year { get; set; }
        [DataMember]
        public List<TrackDto> Tracks { get; set; } 
    }
}
