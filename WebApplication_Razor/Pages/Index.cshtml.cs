using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_Razor.Models;

namespace WebApplication_Razor.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; } = new List<Product>();



        public async Task OnGetAsync()
        {
            Products.Add(new Product()
            {
                Id = 1,
                Description = "First product description",
                Name = "First Product",
                Price = 100,
                Image = "C:\\Users\\Krystyna.Hurieieva\\source\\repos\\ASPNET_Empty\\WebApplication_Razor\\Images\\download (1).jpg",
                Url = "www.google.com"
            });
            Products.Add(new Product()
            {
                Id = 2,
                Description = "Second product description",
                Name = "Second Product",
                Price = 200,
                Image = "C:\\Users\\Krystyna.Hurieieva\\source\\repos\\ASPNET_Empty\\WebApplication_Razor\\Images\\download (2).jpg",
                Url = "www.google.com"
            });
        }
    }
}