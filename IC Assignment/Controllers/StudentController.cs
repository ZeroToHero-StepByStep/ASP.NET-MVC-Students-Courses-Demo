using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IC_Assignment.Models;
using System.Data.Entity;

namespace IC_Assignment.Controllers
{
    public class StudentController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext();
            //            _context.Configuration.AutoDetectChangesEnabled = false;
            //            _context.Configuration.ProxyCreationEnabled = false;
        }

        public ActionResult Index()
        {
            var customers = _context.Students.ToList();
            return View(customers);
        }


        public ActionResult Show()
        {
            var customers = _context.Students.ToList();
            return View(customers);
        }


        public ActionResult Create()
        {
            StudnetFormViewModel studnetFormViewModel = new StudnetFormViewModel()
            {
                Courses = _context.Courses.ToList(),
                Student = new Student()
            };
            foreach (var course in studnetFormViewModel.Courses)
            {
                Console.WriteLine("course :" + course.Name);
            }
            return View("StudentForm", studnetFormViewModel);
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (student.Id == 0)
            {
                Student studentInDb = new Student()
                {
                    Name = student.Name,
                    City = student.City,
                    Age = student.Age,
                    Gender = student.Gender,
                };
                var courseList = new List<Course>();
                foreach (var courseSelect in student.CoursesEnrolled)
                {
                    var courseInDb = _context.Courses.SingleOrDefault(course => course.Id == courseSelect.Id);
                    courseList.Add(courseInDb);
                }
                studentInDb.CoursesEnrolled = courseList;

                _context.Students.Add(studentInDb);

            }
            else
            {
                var studentInDb = _context.Students.Include(s => s.CoursesEnrolled).SingleOrDefault(c => c.Id == student.Id);
                if (studentInDb == null)
                {
                    return HttpNotFound();
                }
                studentInDb.Name = student.Name;
                studentInDb.Age = student.Age;
                studentInDb.City = student.City;
                studentInDb.Gender = student.Gender;

                var courseList = new List<Course>();
                if (student.CoursesEnrolled != null)
                {
                    foreach (var courseSelect in student.CoursesEnrolled)
                    {
                        var courseInDb = _context.Courses.SingleOrDefault(course => course.Id == courseSelect.Id);
                        courseList.Add(courseInDb);
                    }
                }
                studentInDb.CoursesEnrolled = courseList;

                //                studentInDb.CoursesEnrolled = student.CoursesEnrolled;
                //                foreach (var course in studentInDb.CoursesEnrolled)
                //                {
                //                    _context.Entry(course).State = EntityState.Unchanged;
                //                }
                //                _context.Students.Add(studentInDb);
                //                _context.Courses.Attach(studentInDb.CoursesEnrolled);
            }

            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return RedirectToAction("Index", "Student");

        }

        public ActionResult Edit(int id)
        {
            var studentInDb = _context.Students.Include(s => s.CoursesEnrolled).SingleOrDefault(s => s.Id == id);
            if (studentInDb == null)
            {
                return HttpNotFound();
            }
            StudnetFormViewModel studnetFormViewModel = new StudnetFormViewModel()
            {
                Student = studentInDb,
                Courses = _context.Courses.ToList()
            };
            return View("StudentForm", studnetFormViewModel);
        }

        public ActionResult Delete(int id)
        {
            var studentInDb = _context.Students.SingleOrDefault(c => c.Id == id);
            if (studentInDb == null)
            {
                return HttpNotFound();
            }
            _context.Students.Remove(studentInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Student");

        }

        public ActionResult TestKnockoutPage()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            var studentInDb = _context.Students.Include(c => c.CoursesEnrolled).SingleOrDefault(c => c.Id == id);
            return View(studentInDb);
        }
    }
}