using StyleSphere.Models;

namespace StyleSphere.ViewModels
{
    public class ProductViewModel
    {

            public ProductViewModel()
            {
                SizeList = new List<SizesMaster>();
                ColorList = new List<ColorMaster>();

            }
            public int ProductId { get; set; }

            public string ProductName { get; set; }

            public int ColorCount { get; set; }

            public decimal Price { get; set; }

            public string ThumbnailImage { get; set; }

            public string Image1 { get; set; }

            public string Image2 { get; set; }

            public string Image3 { get; set; }

            public string Description { get; set; }

            public decimal Ratings { get; set; }

            public int NoofRatings { get; set; }

            public List<SizesMaster> SizeList;

            public List<ColorMaster> ColorList;


    }
}


