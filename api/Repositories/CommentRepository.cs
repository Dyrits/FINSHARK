using System.Diagnostics;
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
    
    public async Task<Comment> Create(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }
    
    public async Task<Comment> Update(Comment comment)
    {
        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();
        return comment;
    }
    
    public async Task Delete(Comment comment)
    {
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }
}