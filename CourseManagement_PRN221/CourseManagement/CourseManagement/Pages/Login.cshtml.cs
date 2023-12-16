using CrouseManagement.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Repository;

namespace CourseManagement.Pages
{
    public class LoginModel : PageModel
    {
        public readonly StudentRepository _userServices;
        private readonly IConfiguration _configuration;
        public LoginModel(StudentRepository userServices, IConfiguration configuration)
        {
            _userServices = userServices;
            _configuration = configuration;
        }
        [BindProperty]
        public CrouseManagement.Repository.Models.Student Account { get; set; } = default!;
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string adminEmail = _configuration["AdminAccount:Email"];
            string adminPassword = _configuration["AdminAccount:Password"];

            if (!ModelState.IsValid)
            {
                return Page();
            }

           if (Account.Email == adminEmail && Account.Password == adminPassword)
        {
            HttpContext.Session.SetString("isAdmin", "true");
            return RedirectToPage("./CoursePage/CourseMainPage");
        }
        else
        {
            // Kiểm tra thông tin đăng nhập thông thường
            var account = _userServices.GetAll().FirstOrDefault(p => p.Email.Equals(Account.Email) && p.Password.Equals(Account.Password));
            if (account == null)
            {
                ViewData["Message"] = "Email or password incorrect!";
                return Page();
            }

            HttpContext.Session.SetString("Email", account.Email);
            HttpContext.Session.SetInt32("Id", account.Id);
            int id = HttpContext.Session.GetInt32("Id") ?? 0;
            var email = HttpContext.Session.GetString("Email");
             return RedirectToPage("./CoursePage/CourseStudentPage");
        }
        }
    }
}
