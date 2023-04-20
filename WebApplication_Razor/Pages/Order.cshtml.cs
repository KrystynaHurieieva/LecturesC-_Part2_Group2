using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_Razor.Models;

namespace WebApplication_Razor.Pages
{
    public class OrderModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }

        [BindProperty, EmailAddress, Required, Display(Name ="Your email address")]
        public string Email { get; set; }

        [BindProperty, Required(ErrorMessage ="It's required"), Display(Name = "Your address")]
        public string Address { get; set; }

        [BindProperty, Display(Name = "Count")]
        public int Count { get; set; } = 1;
        public Product Product { get; set; }

        public async Task OnGetAsync() => Product = new Product()
        {
            Id = 1,
            Description = "First product description",
            Name = "First Product",
            Price = 100,
            Image = "C:\\Users\\Krystyna.Hurieieva\\source\\repos\\ASPNET_Empty\\WebApplication_Razor\\Images\\download (1).jpg",
            Url = "www.google.com"
        };

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("OrderSuccess");
            }
            return Page();
        }
}
}
