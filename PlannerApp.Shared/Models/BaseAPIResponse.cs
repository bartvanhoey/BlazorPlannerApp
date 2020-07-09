namespace PlannerApp.Shared.Models
{
  public abstract class BaseAPIResponse
  {
    string Message { get; set; }
    bool IsSuccess { get; set; }
  }
}