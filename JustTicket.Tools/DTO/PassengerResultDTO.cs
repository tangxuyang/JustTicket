using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTicket.Tools.DTO
{
    class PassengerResultDTO
    {
        public PassengerResultDataDTO data { get; set; }
        public int httpstatus { get; set; }
        public bool status { get; set; }
        public object validateMesssages { get; set; }
        public string validateMessageShowId { get; set; }
    }
}
