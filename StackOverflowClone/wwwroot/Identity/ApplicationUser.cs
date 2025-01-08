using Microsoft.AspNetCore.Identity;

namespace StackOverflowClone.Models;

public class ApplicationUser:IdentityUser
{
    public string? DisplayName { get; set; }
    public int Reputation { get; set; }
    public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    
}