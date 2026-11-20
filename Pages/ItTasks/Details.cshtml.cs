using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab12_12auth_validation_findrik.Data;
using wt_lab12_12auth_validation_findrik.Models;

namespace wt_lab12_12auth_validation_findrik.Pages.ItTasks;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public ItTask? Task { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Task = await _context.Tasks.FindAsync(id);
        if (Task == null)
        {
            return NotFound();
        }
        return Page();
    }
}