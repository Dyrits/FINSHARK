using api.DTOs.Comment;
using api.Interfaces;
using api.Mappers;

namespace api.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _repository;
    
    public CommentService(ICommentRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<IdentifiedCommentDTO>> GetAll()
    {
        var comments = await _repository.GetAll();
        return comments.Select(comment => comment.ToCommentDTO()).ToList();
    }
    
    public async Task<IdentifiedCommentDTO?> GetById(int id)
    {
        var comment = await _repository.GetById(id);
        return comment?.ToCommentDTO();
    }
}