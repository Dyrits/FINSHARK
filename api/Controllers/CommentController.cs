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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var comments = await _service.GetAll();
        return Ok(comments);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var comment = await _service.GetById(id);
        return comment == null ? NotFound() : Ok(comment);
    }

    [HttpPost("/api/stocks/{id:int}/comments")]
    public async Task<IActionResult> Create([FromRoute] int id, [FromBody] BaseCommentDTO data)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var comment = await _service.Update(id, data);
        return comment == null ? NotFound() : Ok(comment);
    }
    
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] PartialCommentDTO data)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var comment = await _service.Update(id, data);
        return comment == null ? NotFound() : Ok(comment);
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