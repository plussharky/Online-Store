using System.Collections.Generic;
using Store.Models;

namespace Store.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> products { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public string? currentCategory { get; set; }
    }
}
