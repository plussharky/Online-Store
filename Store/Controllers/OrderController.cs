using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System.Linq;
using System.Diagnostics;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout()
        {
            return View(new Order());
        }

        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");          
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
             return View(order);
        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}
