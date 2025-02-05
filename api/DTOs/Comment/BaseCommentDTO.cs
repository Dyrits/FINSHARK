using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Comment;

public class BaseCommentDTO: PartialCommentDTO
{
    [Required]
    [MinLength(8, ErrorMessage = "Title must be at least 8 characters long.")]
    [MaxLength(128, ErrorMessage = "Title must not be more than 128 characters long.")]
    public new string Title { get; set; } = String.Empty;
    
    [Required]
    [MinLength(8, ErrorMessage = "Content must be at least 8 characters long.")]
    [MaxLength(1024, ErrorMessage = "Title must not be more than 1024 characters long.")]
    public new string Content { get; set; } = String.Empty;
}