namespace StackOverflowClone.Features.Questions.Commands.Interfaces;

public interface ICreateQuestionCommand
{
    Task<int> Handle(CreateQuestionCommand command, CancellationToken cancellationToken);
}