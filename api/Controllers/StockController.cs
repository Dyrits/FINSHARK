using api.Data;
using api.DTOs.Stock;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;

[Route("api/stocks")]
public class StockController : Controller
{
    private readonly ApplicationDbContext _context;

    public StockController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var stocks = await _context.Stocks.ToListAsync();
        return Ok(stocks.Select(stock => stock.ToStockDTO()));;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var stock = await _context.Stocks.FindAsync(id);
        if (stock == null)
        {
            return NotFound();
        }

        return Ok(stock.ToStockDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NewStockDTO data)
    {
        var stock = data.ToStock();
       await  _context.Stocks.AddAsync(stock);
        await _context.SaveChangesAsync();

        // Returns the new stock using the GetById method, passing the new stock's ID.
        return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToStockDTO());
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatedStockDTO data)
    {
        var stock = await _context.Stocks.FindAsync(id);
        if (stock == null)
        {
            return NotFound();
        }

        stock.UpdateFrom(data);

        await _context.SaveChangesAsync();
        return Ok(stock.ToStockDTO());
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var stock = await _context.Stocks.FindAsync(id);
        if (stock == null)
        {
            return NotFound();
        }

        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}