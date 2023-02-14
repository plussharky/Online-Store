using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Models.ViewModels;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int productPage = 1)
        {
            return View(new ProductsListViewModel
            {
                pagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                     repository.Products.Count() :
                     repository.Products.Where(p => p.Category == category)
                     .Count()
                },
                products = repository.Products
                 .Where(p => category == null || p.Category == category)
                 .OrderBy(p => p.ProductID)
                 .Skip((productPage - 1) * PageSize)
                 .Take(PageSize),
                currentCategory = category
            });
        }

        public IActionResult Search(string name)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction(nameof(List));
            List<Product> a = repository.Products.Where(x => x.Name.ToUpper().Contains(name.ToUpper())).ToList();
            List<Product> b = repository.Products.Where(x => x.Description.ToUpper().Contains(name.ToUpper())).ToList();
            IQueryable <Product> searchProducts = repository.Products
                .Where(x => x.Name.ToUpper().Contains(name.ToUpper())
                || x.Description.ToUpper().Contains(name.ToUpper()));
            TempData["request"] = name;
            return View(searchProducts);
        }

        public IActionResult About(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
                return NotFound(); // Not Found 
            return View(product);
        }
    }
}
