using System.ComponentModel.DataAnnotations;

namespace StackOverflowClone.Models;

public class Question
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public required string Title { get; set; }
    
    [Required]
    public required string Content { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    
    public required string UserId { get; set; }
    
    public int ViewCount { get; set; }
    
    public int VoteCount { get; set; }
    
    public virtual ApplicationUser User { get; set; }
}