using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_findrik.Models;
using wt_lab5_5razor_findrik.Data;

namespace wt_lab5_5razor_findrik.Pages.ItTasks;

public class IndexModel : PageModel
{
    public List<ItTask> Tasks { get; set; } = new();

    public void OnGet()
    {
        Tasks = ItTaskStore.Tasks;
    }

    // Обработчик удаления
    public IActionResult OnPostDelete(int id)
    {
        var task = ItTaskStore.Tasks.FirstOrDefault(x => x.Id == id);
        if (task != null)
        {
            ItTaskStore.Tasks.Remove(task);
        }
        return RedirectToPage("./Index");
    }
}