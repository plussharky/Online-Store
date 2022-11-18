using Store.Models;

namespace Store.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart cart { get; set; }
        public string returnUrl { get; set; }
    }
}
