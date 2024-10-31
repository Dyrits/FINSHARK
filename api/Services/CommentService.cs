using api.DTOs.Comment;
using api.Interfaces;
using api.Mappers;
using Newtonsoft.Json;

namespace api.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _comments;
    private readonly IStockRepository _stocks;
    
    public CommentService(ICommentRepository comments, IStockRepository stocks)
    {
        _comments = comments;
        _stocks = stocks;
    }
    
    public async Task<List<IdentifiedCommentDTO>> GetAll()
    {
        var comments = await _comments.GetAll();
        return comments.Select(comment => comment.ToCommentDTO()).ToList();
    }
    
    public async Task<IdentifiedCommentDTO?> GetById(int id)
    {
        var comment = await _comments.GetById(id);
        return comment?.ToCommentDTO();
    }

    public async Task<IdentifiedCommentDTO> Create(int id, BaseCommentDTO data)
    {
        if (!await _stocks.Exists(id))
        {
            throw new ArgumentException($"Stock with id {id} does not exist.");
        }
        var comment = await _comments.Create(data.ToComment(id));
        return comment.ToCommentDTO();
    }
    
    public async Task<IdentifiedCommentDTO?> Update(int id, PartialCommentDTO data)
    {
        var comment = await _comments.GetById(id);
        if (comment == null)
        {
            return null;
        }
        comment.UpdateFrom(data);
        comment = await _comments.Update(comment);
        return comment.ToCommentDTO();
    }
    
    public async Task<bool> Delete(int id)
    {
        var comment = await _comments.GetById(id);
        if (comment == null)
        {
            return false;
        }
        await _comments.Delete(comment);
        return true;
    }
}