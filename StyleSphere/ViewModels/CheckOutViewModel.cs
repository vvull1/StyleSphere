namespace StyleSphere.ViewModels
{
    public class CheckOutViewModel

    {
        public CheckOutViewModel()
        {
            OrderDetails = new List<CheckoutDetails>();
        }
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShippingAddress { get; set; } = null!;

        public string BillingAddress { get; set; } = null!;

        public string TrackingId { get; set; } = null!;

        public decimal NetAmount { get; set; }

        public bool ActiveStatus { get; set; }

        public virtual ICollection<CheckoutDetails> OrderDetails { get; set; }

        //public List<ProductsModel> ProductsModels { get; set; }
    }

    //public class ProductsModel
    //{
    //    public int ProductId { get; set;}
    //    public string Quantity { get; set; }
    //}

}
