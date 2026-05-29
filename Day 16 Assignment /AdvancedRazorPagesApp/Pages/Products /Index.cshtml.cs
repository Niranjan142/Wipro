using AdvancedRazorPagesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdvancedRazorPagesApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        // Product list
        public List<Product> Products { get; set; }
            = new List<Product>();

        // Complex model binding
        [BindProperty]
        public Product NewProduct { get; set; }
            = new Product();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Add sample categories
            NewProduct.Categories.Add
            (
                new Category
                {
                    CategoryId = 1,
                    Name = "Electronics"
                }
            );

            NewProduct.Categories.Add
            (
                new Category
                {
                    CategoryId = 2,
                    Name = "Accessories"
                }
            );

            Products.Add(NewProduct);

            return Page();
        }
    }
}
