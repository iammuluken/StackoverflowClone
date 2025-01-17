using MediatR;
using Microsoft.EntityFrameworkCore;
using StackOverflowClone.Features.Questions.Commands.Interfaces;

namespace StackOverflowClone.Features.Questions.Queries;

public class GetQuestionsQueryHandler:IRequestHandler<GetQuestionsQuery, IEnumerable<QuestionListDto>>, IGetQuestionsQuery
{
    private readonly ApplicationDbContext _context;

    public GetQuestionsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<QuestionListDto>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Questions
            .Include(q => q.UserId)
            .Select(q => new QuestionListDto
            {
                Id = q.Id,
                Title = q.Title,
                Content = q.Content,
                CreatedDate = q.CreatedDate,
                VoteCount = q.VoteCount,
                UserName = q.User.UserName ?? "Anonymous"
            })
            .ToListAsync(cancellationToken);
        
    }
}