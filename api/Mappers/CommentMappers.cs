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
        };
    }

    public static Comment ToComment(this BaseCommentDTO comment)
    {
        return new Comment
        {
            Id = comment.Id,
            Title = comment.Title,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
        };
    }

    public static void UpdateFrom(this Comment comment, PartialCommentDTO data)
    {
        comment.Title = data.Title ?? comment.Title;
        comment.Content = data.Content ?? comment.Content;
        comment.CreatedAt = data.CreatedAt ?? comment.CreatedAt;
    }
}