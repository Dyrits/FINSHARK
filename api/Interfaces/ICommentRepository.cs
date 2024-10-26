using api.Models;

namespace api.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAll();
    Task<Comment?> GetById(int id);
    Task<Comment> Create(Comment data);
}