using MediatR;
using Microsoft.EntityFrameworkCore;
using StackOverflowClone.Features.Questions.Commands.Interfaces;

namespace StackOverflowClone.Features.Questions.Queries;

public class GetQuestionDetailQueryHandler:IRequestHandler<GetQuestionDetailQuery,QuestionDetailDto?>,
    IGetQuestionDetailQuery
{
    private readonly ApplicationDbContext _context;

    public GetQuestionDetailQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
        
    public async Task<QuestionDetailDto?> Handle(GetQuestionDetailQuery request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions
            .Include(q=> q.User)
            .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);

        if (question == null)
        {
            return null;
        }

        return new QuestionDetailDto()
        {
            Id = question.Id,
            Title = question.Title,
            Content = question.Content,
            CreatedDate = question.CreatedDate,
            VoteCount = question.VoteCount,
            UserName = question.User?.UserName ?? "Anonymous"
        };
    }
}