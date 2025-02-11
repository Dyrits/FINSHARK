using api.DTOs.Stock;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api;

[Route("/api/stocks")]
public class StockController : Controller
{
    private readonly IStockService _service;

    public StockController(IStockService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stocks = await _service.GetAll();
        return Ok(stocks);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stock = await _service.GetById(id);
        return stock == null ? NotFound() : Ok(stock);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BaseStockDTO data)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stock = await _service.Create(data);
        return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BaseStockDTO data)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stock = await _service.Update(id, data);
        return stock == null ? NotFound() : Ok(stock);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PartialStockDTO data)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stock = await _service.Update(id, data);
        return stock == null ? NotFound() : Ok(stock);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var success = await _service.Delete(id);
        return success ? NoContent() : NotFound();
    }
}