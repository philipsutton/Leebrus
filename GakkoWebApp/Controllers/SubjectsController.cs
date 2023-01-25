using GakkoWebApp.Models;
using GakkoWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GakkoWebApp.Controllers;

public class SubjectsController : Controller
{
    private readonly ISubjectService _subjectService;

    public SubjectsController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

        [HttpGet]
        public IActionResult Index(string query)
        {
            var list = _subjectService.GetSubjects(query);
            return View(list);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Subject newSubject)
        {
            _subjectService.InsertSubject(newSubject);
            return RedirectToAction("Index");
        }
}