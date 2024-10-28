namespace api.DTOs.Comment;

public class BaseCommentDTO: PartialCommentDTO
{
    public new string Title { get; set; } = String.Empty;
    public new string Content { get; set; } = String.Empty;
}