using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_findrik.Models;
using wt_lab5_5razor_findrik.Data;

namespace wt_lab5_5razor_findrik.Pages.ItTasks;

public class CreateModel : PageModel
{
    [BindProperty]
    public ItTask NewTask { get; set; } = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        NewTask.Id = ItTaskStore.Tasks.Any() ? ItTaskStore.Tasks.Max(x => x.Id) + 1 : 1;
        ItTaskStore.Tasks.Add(NewTask);

        return RedirectToPage("./Index");
    }
}