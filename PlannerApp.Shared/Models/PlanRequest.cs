using System.ComponentModel.DataAnnotations;
using System.IO;

namespace PlannerApp.Shared.Models
{
  public class PlanRequest
  {
    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [StringLength(265)]
    public string Description { get; set; }

    public Stream CoverFile { get; set; }

    public string FileName { get;  set; }
  }
}