using api.DTOs.Comment;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api;

[Route("/api/comments")]
public class CommentController : Controller
{
    private readonly ICommentService _service;

    public CommentController(ICommentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _service.GetAll();
        return Ok(comments);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await _service.GetById(id);
        return comment == null ? NotFound() : Ok(comment);
    }

    [HttpPost("/api/stocks/{id:int}/comments")]
    public async Task<IActionResult> Create([FromRoute] int id, [FromBody] BaseCommentDTO data)
    {
        try
        {
            var comment = await _service.Create(id, data);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
        }
        catch (ArgumentException exception)
        {
            return BadRequest(exception.Message);
        }
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BaseCommentDTO data)
    {
        var comment = await _service.Update(id, data);
        return comment == null ? NotFound() : Ok(comment);
    }
    
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] PartialCommentDTO data)
    {
        var comment = await _service.Update(id, data);
        return comment == null ? NotFound() : Ok(comment);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var success = await _service.Delete(id);
        return success ? NoContent() : NotFound();
    }
}