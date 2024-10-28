using api.DTOs.Comment;

namespace api.DTOs.Stock;

public class IdentifiedStockDTO: BaseStockDTO
{
    public new int Id { get; set; }
    
    public List<IdentifiedCommentDTO> Comments { get; set; } = new ();
}