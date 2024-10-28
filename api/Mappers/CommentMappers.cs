using api.DTOs.Comment;
using api.Models;

namespace api.Mappers;

public static class CommentMappers
{
    public static IdentifiedCommentDTO ToCommentDTO(this Comment comment)
    {
        return new IdentifiedCommentDTO
        {
            Id = comment.Id,
            Title = comment.Title,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            StockId = comment.StockId
        };
    }

    /**
     * <summary>
     * Maps a comment DTO to a comment model.
     * </summary>
     * <param name="comment">The comment DTO (BaseCommentDTO).</param>
     * <params name="id">The stock id (int).</params>
     * <returns>The comment model (Comment).</returns>
    */
    public static Comment ToComment(this BaseCommentDTO comment, int id)
    {
        return new Comment
        {
            Title = comment.Title,
            Content = comment.Content,
            StockId = id
        };
    }

    public static void UpdateFrom(this Comment comment, PartialCommentDTO data)
    {
        comment.Title = data.Title ?? comment.Title;
        comment.Content = data.Content ?? comment.Content;
    }
}