namespace StyleSphere.ViewModels
{
    public class CheckOutViewModel
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public string ProductName { get; set; }

        public string ThumbnailImage { get; set; }

        public string Quantity { get; set; }

        public string Color { get; set; }

        public string Eusize { get; set; } 

        public string Ussize { get; set; } 

        public decimal Price { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShippingAddress { get; set; }
        
        public string BillingAddress { get; set; }

        public string TrackingId { get; set; } = null!;

        public decimal NetAmount { get; set; }
        //public List<ProductsModel> ProductsModels { get; set; }
    }

    //public class ProductsModel
    //{
    //    public int ProductId { get; set;}
    //    public string Quantity { get; set; }
    //}

}
