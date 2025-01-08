using Microsoft.AspNetCore.Mvc;
using StackOverflowClone.Models;

namespace StackOverflowClone.Controllers;

public class QuestionsController : Controller
{
    private readonly ApplicationDbContext _context;

    public QuestionsController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        var question = _context.Questions.FirstOrDefault(q => q.Id == id);
        if (question == null)
        {
            return NotFound();
        }
        return View(question);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Question question)
    {
        if (ModelState.IsValid)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(question);
    }
  
}