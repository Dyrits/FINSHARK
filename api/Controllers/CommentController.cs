using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api;

[Route("api/comments")]
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
    public async Task<IActionResult> GetById([FromRoute] int id) {
        var comment = await _service.GetById(id);
        return comment == null ? NotFound() : Ok(comment);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BaseCommentDTO data)
    {
        var comment = await _service.Create(data);
        return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
    }
}