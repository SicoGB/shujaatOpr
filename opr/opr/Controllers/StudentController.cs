using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using opr.Models;
namespace opr.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {

            Models.oprEntities dt = new oprEntities();
            ViewBag.UserId = User.Identity.GetUserId();
            List<Models.StudentTable> model = new List<StudentTable>();

            model = dt.StudentTables.ToList();
            //{
            //    Models.ClassEntities db = new ClassEntities();
            //    var mod = db.SchoolTables.Select(c => new { c.school_id, c.school_name }).ToList();
            //    SelectList selectList = new SelectList(mod, "school_id", "school_name", 3);

            //    ViewBag.dataForDropDown = selectList;

            //    var mods = db.ClassTables.Select(c => new { c.class_id, c.class_name }).ToList();
            //    SelectList selectLists = new SelectList(mods, "class_id", "class_name");
            //    ViewBag.dataForDropDowns = selectLists;

            return View(model);
    }
        public ActionResult AddStudent()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(opr.Models.StudentTable model)
        {
            oprEntities db = new oprEntities();


            db.StudentTables.Add(model);

            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteStudent(int id)
        {

            Models.oprEntities db = new oprEntities();
            StudentTable classdt = db.StudentTables.Find(id);
            classdt.IsDeleted = true;
            db.Entry(classdt).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditStudent(int id)
        {
            ViewBag.ModifiedBy = User.Identity.GetUserName();

            Models.oprEntities db = new oprEntities();
        
            StudentTable edata = db.StudentTables.Find(id);


            return View(edata);
        }
        [HttpPost]
        public ActionResult EditStudent(opr.Models.StudentTable model)
        {
            oprEntities cls = new oprEntities();
           
            cls.Entry(model).State = System.Data.Entity.EntityState.Modified;
            try
            {
                cls.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

            }
            ModelState.AddModelError("", "Unable to save changes");

            return View(model);
        }
    }
}