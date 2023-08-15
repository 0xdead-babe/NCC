using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            var _students = _studentService.GetAllStudents();
            return View(_students);
        }

        public IActionResult Details(int id)
        {
            return Content($"Hehe this is the route student/{id}");
        }

        [HttpGet]
        public IActionResult Create() { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student) 
        {

            if(ModelState.IsValid)
            {
                _studentService.CreateStudent(student);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }



		public IActionResult Edit(int id)
		{
			var _student = _studentService.GetStudentById(id);
            if(_student !=null)
            {
                return View(_student);
            }
            return NotFound();
		}

        [HttpPost]
		public IActionResult Edit(Student student)
        {
            if(ModelState.IsValid)
            {
                var _student = _studentService.GetStudentById(student.Id);

                if(_student != null)
                {
                    _student.Name = student.Name;
                    _student.Age = student.Age;
                    _studentService.UpdateStudent(_student);
					return RedirectToAction("Index");

				}
                return NotFound();
			}

            else
            {
                return View();
            }
		}

        [HttpGet]
        public IActionResult Delete(int id) {

            if(_studentService.DeleteStudent(id))
            {
				return RedirectToAction("Index");

			}

            return NotFound();

		}
    }
}
