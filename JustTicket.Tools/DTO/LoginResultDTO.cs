using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTicket.Tools.DTO
{
    public class LoginResultDTO
    {
        public string validateMessageShowId { get; set; }
        public bool status { get; set; }
        public int httpstatus { get; set; }
        public LoginResultDataDTO data { get; set; }
        public List<string> messages { get; set; }
        public object validateMessages { get; set; }
    }
}
