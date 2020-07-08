using System;

namespace PlannerApp.Shared.Models
{
    public class UserManagerResponse
    {
        public string   Message { get; set; }
        public bool IsSuccess { get; set; }
        public string[] Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}