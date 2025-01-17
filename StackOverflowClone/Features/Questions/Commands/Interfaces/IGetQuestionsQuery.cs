using StackOverflowClone.Features.Questions.Queries;

namespace StackOverflowClone.Features.Questions.Commands.Interfaces;

public interface IGetQuestionsQuery
{
    Task<IEnumerable<QuestionListDto>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken);
}