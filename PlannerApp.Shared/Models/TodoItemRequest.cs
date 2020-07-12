using System.ComponentModel.DataAnnotations;

namespace PlannerApp.Shared.Models
{
  public class TodoItemRequest
  {
    public string Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Description { get; set; }

    public string PlanId { get; set; }
  }
}