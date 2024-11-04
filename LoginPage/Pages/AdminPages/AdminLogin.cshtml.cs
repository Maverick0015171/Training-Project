using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginPage.Pages.AdminPages
{
    public class AdminLoginModel : PageModel
    {
        [BindProperty]
        public string AdminUsername { get; set; }
        [BindProperty]
        public string AdminPassword { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (AdminUsername == "admin" && AdminPassword == "admin")
            {
                TempData["Message"] = "Admin Login Success";
                TempData["link"] = "/AdminHome";
                TempData["LoginError"] = "Admin Account Dosent Exist please provide valid credentials";
                return RedirectToPage("Response");
            }


            return Page();

            //TempData["isLogin"] = "True";
        }
    }
}
