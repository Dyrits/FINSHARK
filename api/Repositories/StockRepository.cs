using api.Data;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class StockRepository: IStockRepository
{
    private readonly ApplicationDbContext _context;
    
    public StockRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Stock>> GetAll()
    {
       return await _context.Stocks.ToListAsync();
    }

    public async Task<Stock?> GetById(int id)
    {
       return await _context.Stocks.FindAsync(id);
    }

    public async Task<Stock> Create(Stock stock)
    {
        await _context.Stocks.AddAsync(stock);
        await _context.SaveChangesAsync();
        return stock;
    }

    public async Task<Stock> Update(Stock stock)
    {
        _context.Stocks.Update(stock);
        await _context.SaveChangesAsync();
        return stock;
    }

    public async Task Delete(Stock stock)
    {
        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();
    }
}