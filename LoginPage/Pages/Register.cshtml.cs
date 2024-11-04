using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using LoginPage.Pages.Shared.RegisterModelClass;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoginPage.Data.Context;
using LoginPage.Data.Entity;

namespace LoginPage.Pages
{
    public class RegisterModel : PageModel
    {

        private readonly AppDbContext _context;

        public readonly IWebHostEnvironment _environment;

        public RegisterModel(AppDbContext context, IWebHostEnvironment _env)
        {
            _context = context;
            _environment = _env;
        }



        [BindProperty]
        public RegisterModelClass RegistredUser { get; set; }

        public void PopulateOptions()
        {
            if (RegistredUser == null)
            {
                RegistredUser = new RegisterModelClass();
            }

            RegistredUser.Gender = new List<SelectListItem> {
             new SelectListItem {Value="M",Text="Male"},
             new SelectListItem {Value="F",Text="Female"},
             new SelectListItem {Value="O",Text="Others"},
            };
        }
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
        
            }
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(RegistredUser.ImageFile.FileName);

            var filepath = Path.Combine(_environment.WebRootPath,"Upload", filename);

            var fileStream = new FileStream(filepath, FileMode.Create);
            RegistredUser.ImageFile.CopyToAsync(fileStream);

            var newCus = new Customer
            {
                Name = RegistredUser.Username,
                Email = RegistredUser.Email,
                Password = RegistredUser.Password,
                ConfirmPassword=RegistredUser.ConfirmPassword,
                Age = RegistredUser.Age,
                ImgPath=filename
            }; 
            _context.customers.Add(newCus);
            _context.SaveChanges();
            TempData["Message"] = "Account Created Successfully";
            TempData["link"] = "/Signup";
            return RedirectToPage("Response");
        }

        public void OnGet()
        {
            PopulateOptions();
        }

    }
}


