using api.DTOs.Comment;

namespace api.Interfaces;

public interface ICommentService
{
    Task<List<IdentifiedCommentDTO>> GetAll();
    Task<IdentifiedCommentDTO?> GetById(int id);
    Task<IdentifiedCommentDTO> Create(BaseCommentDTO data);
}