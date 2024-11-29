using Microsoft.AspNetCore.Mvc;
using WebByDal.DAL;
using WebByDal.Models;

namespace WebByDal.Controllers
{
    public class HomeController : Controller
    {   
        StudentDal stdal=new StudentDal();
        public IActionResult Index()
        {
           List<Student>List = stdal.GetStudents().ToList();
            return View("Index",List);
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        public ActionResult AfterCreate(Student studetToAdd)
        {
            int rows=stdal.AddStudent(studetToAdd);
            return Redirect("/Home/Index");
        }
        public IActionResult Edit(int id)
        {
            Student student= stdal.GetStudent(id);
            return View("Edit",student);
        }
        public IActionResult AfterEdit(Student s)
        {
            int rows = stdal.UpdateStudent(s);
            return Redirect("/Home/Index");
        }
        public IActionResult Delete(int id) 
        {
            int row=stdal.DeleteStudent(id);
            return Redirect("/Home/Index");
        }

    }
}
