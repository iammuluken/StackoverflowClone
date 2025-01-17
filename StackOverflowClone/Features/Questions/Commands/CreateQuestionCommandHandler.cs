using MediatR;
using StackOverflowClone.Features.Questions.Commands.Interfaces;
using StackOverflowClone.Models;
namespace StackOverflowClone.Features.Questions.Commands;

public class CreateQuestionCommandHandler:IRequestHandler<CreateQuestionCommand,int>, ICreateQuestionCommand
{
    private readonly ApplicationDbContext _context;

    public CreateQuestionCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateQuestionCommand command, CancellationToken cancellationToken)
    {
        var question = new Question
        {
            Title = command.Title,
            Content = command.Content,
            UserId = "1",
            CreatedDate = DateTime.UtcNow
        };
        
        _context.Questions.Add(question);
        await _context.SaveChangesAsync(cancellationToken);
        return question.Id;
    }
}