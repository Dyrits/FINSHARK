namespace api.DTOs.Comment;

public class BaseCommentDTO: PartialCommentDTO
{
    public new int Id { get; set; }
    public new string Title { get; set; } = String.Empty;
    public new string Content { get; set; } = String.Empty;
    public new DateTime CreatedAt { get; set; } = DateTime.Now;
}