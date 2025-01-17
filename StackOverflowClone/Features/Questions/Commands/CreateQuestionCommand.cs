using MediatR;

namespace StackOverflowClone.Features.Questions.Commands;

public class CreateQuestionCommand : IRequest<int>
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string UserId { get; set; }
}