namespace StyleSphere.ViewModels
{
    public class CheckoutDetails
    {
        public int OrderDetailsId { get; set; }

        public int OrderId { get; set; }

        public int ProductMappingId { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }

        //public decimal Total { get; set; }

        public bool ActiveStatus { get; set; }
    }
}
