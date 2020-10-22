using lab5.Data;
using lab5.Views.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index() {
            List<StudentModel> students = new List<StudentModel>();
            StudentDAO studentDAO = new StudentDAO();
            students = studentDAO.FetchAll();

            return View("Index", students);
        }

        public ActionResult Details (int Id) {
            StudentDAO studentDAO = new StudentDAO();
            StudentModel student = studentDAO.FetchOne(Id);

            return View("Details", student);
        }

        public ActionResult Create() {           
            return View("StudentForm");
        }

        public ActionResult Edit(int Id) {
            StudentDAO studentDAO = new StudentDAO();
            StudentModel student = studentDAO.FetchOne(Id);

            return View("StudentForm", student);
        }

        public ActionResult Delete(int Id) {
            StudentDAO studentDAO = new StudentDAO();
            studentDAO.Delete(Id);

            List<StudentModel> students = studentDAO.FetchAll();

            return View("Index", students);
        }

        public ActionResult ProcessCreate(StudentModel studentModel) {
            StudentDAO studentDAO = new StudentDAO();
            studentDAO.CreateOrUpdate(studentModel);

            return View("Details", studentModel);
        }

        public ActionResult SearchForm() {          
            return View("SearchForm");
        }

        public ActionResult SerachForName(string searchPhrase) {
            StudentDAO studentDAO = new StudentDAO();
            List<StudentModel> searchResults = studentDAO.SerachForName(searchPhrase);

            return View("Index", searchResults);
        }

        public ActionResult SerachForLastname(string searchPhrase) {
            StudentDAO studentDAO = new StudentDAO();
            List<StudentModel> searchResults = studentDAO.SerachForLastname(searchPhrase);

            return View("Index", searchResults);
        }
    }
}