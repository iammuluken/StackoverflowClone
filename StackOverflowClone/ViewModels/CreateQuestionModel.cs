using System.ComponentModel.DataAnnotations;

namespace StackOverflowClone.ViewModels;

public class CreateQuestionModel
{
    [Required(ErrorMessage = "Please enter a title.")]
    [MinLength(5, ErrorMessage = "Title must be at least 5 characters.")]
    [MaxLength(200, ErrorMessage = "Title must be less than 200 characters.")]
    public required string Title { get; set; }
    
    [Required(ErrorMessage = "Please enter a content.")]
    [MinLength(20, ErrorMessage = "Content must be at least 20 characters.")]
    public required string Content { get; set; }
}