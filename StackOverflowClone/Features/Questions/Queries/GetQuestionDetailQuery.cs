using MediatR;

namespace StackOverflowClone.Features.Questions.Queries;

public record GetQuestionDetailQuery : IRequest<QuestionDetailDto?>
{
    public required int Id { get; init; }
}

public class QuestionDetailDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public int VoteCount { get; set; }
    public string? UserName { get; set; }
}
