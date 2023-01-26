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
        [HttpGet]
        public IActionResult Delete(string Name)
        {
            ViewBag.Name = Name;
            return View("Delete");
        }
        [HttpPost]
        public IActionResult Delete(Subject removedSubject)
        {
            _subjectService.DeleteSubject(removedSubject);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Students(int IdSubject, Subject subject)
        {
            ViewBag.IdSubject = IdSubject;
            var list = _subjectService.GetStudentsFromSubject(subject);
            return View("students", list);
        }
        
      
}