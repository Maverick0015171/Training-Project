using Azure;
using LoginPage.Data.Context;
using LoginPage.Data.Entity;
using LoginPage.Pages.Shared.RegisterModelClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoginPage.Pages
{
    public class Edit_pageModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Customer Customer { get; set; }  


        public Edit_pageModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            
        }
        public void OnGetEdit(int? id)
        {
            var user =_context.customers.Find(id);
            Customer = user;
        }
        public IActionResult OnPostSubmit()
        {
            var user = _context.customers.Find(Customer.Id);
            if (user != null)
            {
                user.Name = Customer.Name;
                user.Email = Customer.Email;
                user.Password = Customer.Password;
                user.Age = Customer.Age;
                _context.SaveChanges();
            }

            return RedirectToPage("AdminHome");
        }

    }
}

