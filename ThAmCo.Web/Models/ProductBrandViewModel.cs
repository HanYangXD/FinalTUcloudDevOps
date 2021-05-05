using Microsoft.AspNetCore.Mvc.Rendering;
using Producks.Data;
using System.Collections.Generic;

namespace ThAmCo.Web.Models
{
    public class ProductBrandViewModel
    {
        public List<Product> Products { get; set; }
        public SelectList Brands { get; set; }
        public SelectList Categories { get; set; }
        public string ProductBrand { get; set; }
        public string ProductCategory { get; set; }
        public string SearchString { get; set; }
    }
}
