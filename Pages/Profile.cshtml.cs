using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wt_lab12_12auth_validation_findrik.Pages;

public class ProfileModel : PageModel
{
    public string? UserLogin { get; private set; }

    public IActionResult OnGet()
    {
        // Проверка: есть ли логин в сессии
        UserLogin = HttpContext.Session.GetString("UserLogin");

        if (UserLogin == null)
        {
            // Если нет — на страницу входа
            return RedirectToPage("/Login");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        // Очищаем сессию (выход)
        HttpContext.Session.Clear();

        return RedirectToPage("/Login");
    }
}