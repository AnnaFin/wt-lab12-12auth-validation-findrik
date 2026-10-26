using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_findrik.Models;

public class ItTask
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название задачи")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно быть от 3 до 100 символов")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введите название проекта")]
    public string ProjectName { get; set; } = string.Empty;

    public string Priority { get; set; } = "Medium";

    [Range(1, 500, ErrorMessage = "Оценка должна быть от 1 до 500 часов")]
    public double EstimatedHours { get; set; }

    public bool IsCompleted { get; set; }
}