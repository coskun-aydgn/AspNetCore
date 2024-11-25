using basics.DAL;
using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.CourseController;

public class CourseController : Controller
{
    public IActionResult Details(int? id)
    {
        if(id==null) return Redirect("/course/list");
        var kurs = CourseRepository.GetById(id);

        return View(kurs);
    }
    public IActionResult List()
    {
       
        return View("CourseList", CourseRepository.Courses);
    }
}