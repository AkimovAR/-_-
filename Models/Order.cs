using System;


namespace motoStore.Models
{
    class Order
    {
        public int Id { get; set; }
        public DateTime Order_date { get; set; }
        public string Order_price { get; set; }
        public int Stock_code { get; set; }
        public int Bike_code { get; set; }
        public int Employee_code { get; set; }
        public int Client_code { get; set; }

    }
}
