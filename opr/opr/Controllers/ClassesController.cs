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
    public class ClassesController : Controller
    {
        
        // GET: Classes
        public ActionResult Index()
        {

            Models.oprEntities dt = new oprEntities();
            List<Models.ClassesTable> model = new List<ClassesTable>();

            model = dt.ClassesTables.Where(r=>r.IsActive==true&& r.IsDeleted==true).ToList();

            return View(model);
        }
        public ActionResult AddClass()
        {
            ViewBag.UserId =User.Identity.GetUserId() ;
           
            return View();
        }
        [HttpPost]
        public ActionResult AddClass(opr.Models.ClassesTable model)
        {
            oprEntities db = new oprEntities();

           
            db.ClassesTables.Add(model );

            db.SaveChanges();
            return View();
        }
        
        
        public ActionResult DeleteClass(int id)
        {

            Models.oprEntities db = new oprEntities();
            ClassesTable classdt = db.ClassesTables.Find(id);
            classdt.IsDeleted = true;
            db.Entry(classdt).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditClass(int id)
        {
            ViewBag.ModifiedBy = User.Identity.GetUserName();
            Models.oprEntities db = new oprEntities();
            ClassesTable edata = db.ClassesTables.Find(id);
            

            return View(edata);
        }
        [HttpPost]
        public ActionResult EditClass(opr.Models.ClassesTable model)
        {
            oprEntities cls = new oprEntities();
            model.IsDeleted = true;
            model.IsActive = true;
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