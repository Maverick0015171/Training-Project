using LoginPage.Data.Context;
using LoginPage.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginPage.Pages.AdminPages
{
    public class AdminHomeModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<Customer> CustomerList { get; set; }

        public AdminHomeModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            CustomerList = _context.customers.ToList();
        }
    }
}
