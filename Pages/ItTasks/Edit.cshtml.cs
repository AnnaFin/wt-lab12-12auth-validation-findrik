using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_findrik.Models;
using wt_lab5_5razor_findrik.Data;

namespace wt_lab5_5razor_findrik.Pages.ItTasks;

public class EditModel : PageModel
{
    [BindProperty]
    public ItTask CurrentTask { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var task = ItTaskStore.Tasks.FirstOrDefault(x => x.Id == id);
        if (task == null) return NotFound();

        CurrentTask = task;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var existingTask = ItTaskStore.Tasks.FirstOrDefault(x => x.Id == CurrentTask.Id);
        if (existingTask == null) return NotFound();

        existingTask.Title = CurrentTask.Title;
        existingTask.ProjectName = CurrentTask.ProjectName;
        existingTask.Priority = CurrentTask.Priority;
        existingTask.EstimatedHours = CurrentTask.EstimatedHours;
        existingTask.IsCompleted = CurrentTask.IsCompleted;

        return RedirectToPage("./Index");
    }
}