using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Store.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Please enter a product name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter a description")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Please specify a category")]
        public string Category { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage ="Please enter a positive price")]
        public decimal Price { get; set; }


        public override string ToString()
        {
            return String.Format("ProductID: {0},\nName: {1},\nDescription: {2},\nPrice: {3},\nCategoy: {4}", ProductID, Name, Description, Price, Category);
        }
    }
}
