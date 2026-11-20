using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab12_12auth_validation_findrik.Data;
using wt_lab12_12auth_validation_findrik.Models;

namespace wt_lab12_12auth_validation_findrik.Pages.ItTasks;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public ItTask NewTask { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Tasks.Add(NewTask);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}