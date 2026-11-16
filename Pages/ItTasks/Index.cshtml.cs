using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_findrik.Data;
using wt_lab8_8razor_postgresql_findrik.Models;

namespace wt_lab8_8razor_postgresql_findrik.Pages.ItTasks;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<ItTask> Tasks { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public async Task OnGetAsync()
    {
        var query = _context.Tasks.AsQueryable();

        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(t => t.Title.ToLower().Contains(Search.ToLower()));
        }

        Tasks = await query.OrderBy(t => t.Title).ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage("./Index");
    }
}