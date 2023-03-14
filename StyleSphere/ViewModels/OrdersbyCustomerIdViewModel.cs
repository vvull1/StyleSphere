namespace StyleSphere.ViewModels
{
    public class OrdersbyCustomerIdViewModel
    {
        //public int OrderId { get; set; }
        //public int ProductId { get; set; }
        //public string ProductName { get; set; }
        //public string ProductDescription { get; set; }
        //public DateTime OrderDate { get; set; }
        //public string TrackingId { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShippingAddress { get; set; } = null!;

        public string BillingAddress { get; set; } = null!;

        public string TrackingId { get; set; } = null!;

        public decimal NetAmount { get; set; }

    }
}
