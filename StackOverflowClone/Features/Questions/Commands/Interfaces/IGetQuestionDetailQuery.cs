using StackOverflowClone.Features.Questions.Queries;

namespace StackOverflowClone.Features.Questions.Commands.Interfaces;

public interface IGetQuestionDetailQuery
{
    Task<QuestionDetailDto?> Handle(GetQuestionDetailQuery command, CancellationToken cancellationToken);
}