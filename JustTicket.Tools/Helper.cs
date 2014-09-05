using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustTicket.Tools.DTO;

namespace JustTicket.Tools
{
    public class Helper
    {
        public static string getpassengerTickets(List<LimitTicketDTO> limit_tickets)
        {
            var ax = "";
            for (var ay = 0; ay < limit_tickets.Count; ay++) 
            {
                var az = limit_tickets[ay].seat_type + ",0," + limit_tickets[ay].ticket_type + "," + limit_tickets[ay].name + "," + limit_tickets[ay].id_type + "," + limit_tickets[ay].id_no + "," + (limit_tickets[ay].phone_no == null ? "" : limit_tickets[ay].phone_no) + "," + (limit_tickets[ay].save_status == "" ? "N" : "Y");
                ax += az + "_";
            }
            return ax.Substring(0, ax.Length - 1);
        }

        public static string getOldPassengers(List<LimitTicketDTO> limit_tickets) {
            var aB = "";
            for (var aA = 0; aA < limit_tickets.Count; aA++) 
            {
                var ax = limit_tickets[aA];
                //if (ticketInfoForPassengerForm.tour_flag == ticket_submit_order.tour_flag.fc || ticketInfoForPassengerForm.tour_flag == ticket_submit_order.tour_flag.gc) {
                //    var ay = ax.name + "," + ax.id_type + "," + ax.id_no + "," + ax.passenger_type;
                //    aB += ay + "_"
                //} else {
                //    if (ax.only_id.indexOf("djPassenger_") > -1) {
                //        var az = ax.only_id.split("_")[1];
                //        var ay = L[az].passenger_name + "," + L[az].passenger_id_type_code + "," + L[az].passenger_id_no + "," + L[az].passenger_type;
                //        aB += ay + "_"
                //    } else {
                //        if (ax.only_id.indexOf("normalPassenger_") > -1) {
                //            var az = ax.only_id.split("_")[1];
                //            var ay = aw[az].passenger_name + "," + aw[az].passenger_id_type_code + "," + aw[az].passenger_id_no + "," + aw[az].passenger_type;
                //            aB += ay + "_"
                //        } else {
                //            aB += "_ "
                //        }
                //    }
                //}
            }
            return aB;
        }
    }
}
