using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_findrik.Models;
using wt_lab5_5razor_findrik.Data;

namespace wt_lab5_5razor_findrik.Pages.ItTasks;

public class DetailsModel : PageModel
{
    public ItTask? Task { get; set; }

    public IActionResult OnGet(int id)
    {
        Task = ItTaskStore.Tasks.FirstOrDefault(x => x.Id == id);
        if (Task == null)
        {
            return NotFound();
        }
        return Page();
    }
}