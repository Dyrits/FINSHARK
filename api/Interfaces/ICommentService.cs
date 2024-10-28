using api.DTOs.Comment;

namespace api.Interfaces;

public interface ICommentService
{
    Task<List<IdentifiedCommentDTO>> GetAll();
    Task<IdentifiedCommentDTO?> GetById(int id);
    /**
     * <summary>
     * Create a comment for a stock.
     * </summary>
     * <param name="id">The stock id (int).</param>
     * <param name="data">The comment data (BaseCommentDTO).</param>
     * <returns>The created comment DTO (IdentifiedCommentDTO).</returns>
     */
    Task<IdentifiedCommentDTO> Create(int id, BaseCommentDTO data);
}