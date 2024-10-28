using api.Models;

namespace api.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAll();
    Task<Comment?> GetById(int id);
    /**
     * <summary>
     * Save a comment for a stock.
     * </summary>
     * <param name="id">The stock id (int).</param>
     * <param name="data">The comment data (Comment).</param>
     * <returns>The created comment (Comment).</returns>
    */
    Task<Comment> Create(Comment comment);
}