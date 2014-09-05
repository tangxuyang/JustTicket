using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTicket.Tools.DTO
{
    public class LimitTicketDTO
    {
        public string seat_type { get; set; }
        public string seat_type_name { get; set; }
        public string ticket_type { get; set; }
        public string ticket_type_name { get; set; }
        public string name{get;set;}
        public string id_type { get; set; }
        public string id_type_name { get; set; }
        public string id_no { get; set; }
        public string phone_no { get; set; }
        public string passenter_type { get; set; }
        public string seatTypes { get; set; }
        public string ticketTypes { get; set; }
        public string cardTypes { get; set; }
        public string save_status { get; set; }
        public string tour_flag { get; set; }
        public bool isDisabled { get; set; }
        public bool isDefaultUsed { get; set; }
        public string checkboxStatus { get; set; }
    }
}
