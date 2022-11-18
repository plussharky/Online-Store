using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Infrastructure;
using Strore.Models;
using NuGet.Protocol;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions;
using System;
using System.Web;
using Store.Models.ViewModels;

namespace Store.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;
        private IHttpContextAccessor httpContextAccessor;

        private int _countDelites = 0;
        public CartController(IProductRepository repository,Cart cartService, IHttpContextAccessor httpContextAccessor)
        {
            this.repository = repository;
            this.httpContextAccessor = httpContextAccessor;
            this.cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            //if (cart.Lines.Count() == 0)
            //{
            //    ModelState.AddModelError("cart", "Sorry, your cart is empty!");
            //}
            return View(new CartIndexViewModel
            {
                cart = cart,
                returnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            
            Debug.WriteLine("-----------------RemoveFromCart--------------------");
            Debug.WriteLine("productId: " + productId);
            Debug.WriteLine("returnUrl: " + returnUrl);
           
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            Debug.WriteLine("Prodouct: " + product);
            Debug.WriteLine("Cart before: " + cart);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            Debug.WriteLine("Cart after: " + cart);
            Debug.WriteLine("Delites: " + _countDelites++);
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
