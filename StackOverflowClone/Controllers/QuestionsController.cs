using MediatR;
using Microsoft.AspNetCore.Mvc;
using StackOverflowClone.Features.Questions.Commands;
using StackOverflowClone.Features.Questions.Queries;
using StackOverflowClone.Models;
using StackOverflowClone.ViewModels;

namespace StackOverflowClone.Controllers;

public class QuestionsController : Controller
{
    private readonly IMediator _mediator;

    public QuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var query = new GetQuestionsQuery();
        var questions = await _mediator.Send(query);
        return View(questions);
    }

    public IActionResult Details(int id)
    {
        var query = new GetQuestionDetailQuery() { Id = id };
        var questionDetail = _mediator.Send(query).Result;
        if (questionDetail == null)
        {
            return NotFound();
        }
        return View(questionDetail);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateQuestionModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);
        var command = new CreateQuestionCommand()
        {
            Title = viewModel.Title,
            Content = viewModel.Content,
            UserId = "tempUserId"
        };
            
        var questionId = await _mediator.Send(command);
        return RedirectToAction(nameof(Details), new { id = questionId });
    }
  
}