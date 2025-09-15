using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBillingSystem
{
    internal class Customer
    {
        public string No { get; set; }
        public string Name { get; set; }

        public DateTime checkInDate { get; set; }

        public string RoomType { get; set; }

        public double BarLoungeCharge { get; set; }

        public double RestaurantCharges { get; set; }

        public double WellnessCharges {get; set;}

        public double AirportPickupCharges { get; set; }

        public double NetPaymentCharges { get; set; }

    }

}
