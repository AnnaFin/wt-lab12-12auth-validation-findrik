using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_findrik.Data;
using wt_lab8_8razor_postgresql_findrik.Models;

namespace wt_lab8_8razor_postgresql_findrik.Pages.ItTasks;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public ItTask CurrentTask { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        CurrentTask = await _context.Tasks.FindAsync(id);
        if (CurrentTask == null) return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(CurrentTask).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}