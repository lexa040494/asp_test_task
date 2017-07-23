using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    [DataContract]
    public class TrackDto
    {
        [DataMember]
        public decimal Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Artist { get; set; }
        [DataMember]
        public string Duration { get; set; }
        [DataMember]
        public decimal AlbumId { get; set; } 
    }
}
