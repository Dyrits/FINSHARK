using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class CommentRepository: ICommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Comment>> GetAll()
    {
        return await _context.Comments.ToListAsync();
    }
    
    public async Task<Comment?> GetById(int id)
    {
        return await _context.Comments.FindAsync(id);
    }
    
    public async Task<Comment> Create(Comment data)
    {
        var comment = (await _context.Comments.AddAsync(data)).Entity;
        await _context.SaveChangesAsync();
        return comment;
    }
}