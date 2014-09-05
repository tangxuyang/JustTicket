using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTicket.Tools.DTO
{
    class PassengerResultDataDTO
    {
        public object[] dj_passengers { get; set; }
        public string exMsg { get; set; }
        public bool isExist { get; set; }
        public List<NormalPassengerDTO> normal_passengers { get; set; }
        public List<string> other_isOpenClick { get; set; }
        public List<string> two_isOpenClick { get; set; }
    }
}
