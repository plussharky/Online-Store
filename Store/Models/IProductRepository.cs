using System.Linq;

namespace Store.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
