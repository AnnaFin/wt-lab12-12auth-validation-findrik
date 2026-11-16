using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_findrik.Data;
using wt_lab8_8razor_postgresql_findrik.Models;

namespace wt_lab8_8razor_postgresql_findrik.Pages.ItTasks;

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