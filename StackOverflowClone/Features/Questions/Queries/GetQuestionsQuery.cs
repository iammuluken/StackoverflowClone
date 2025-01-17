using MediatR;

namespace StackOverflowClone.Features.Questions.Queries;

public record GetQuestionsQuery : IRequest<IEnumerable<QuestionListDto>>;

public class QuestionListDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public int VoteCount { get; set; }
    public string? UserName { get; set; }
}
