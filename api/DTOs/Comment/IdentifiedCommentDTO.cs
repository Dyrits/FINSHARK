namespace api.DTOs.Comment;

public class IdentifiedCommentDTO: BaseCommentDTO
{
    public int Id { get; set; }
    public new DateTime CreatedAt { get; set; } = DateTime.Now;
    public new int StockId { get; set; }
}