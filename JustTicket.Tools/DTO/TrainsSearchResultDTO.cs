using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTicket.Tools.DTO
{
    class TrainsSearchResultDTO
    {
        public List<TrainsSearchResultItemDTO> data { get; set; }
        public int httpstatus { get; set; }
        public string[] messages { get; set; }
        public bool status { get; set; }
        public object validateMessages { get; set; }
        public string validateMessageShowId { get; set; }
    }
}
