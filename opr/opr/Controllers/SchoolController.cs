using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using opr.Models;
using Microsoft.AspNet.Identity;
namespace opr.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {
            Models.opr1Entities db = new opr1Entities();
            List<Models.School> model = new List<School>();
            model = db.Schools.ToList();
            return View(model);
            
        }

        public ActionResult EditSchool(int id)
        {

            Models.opr1Entities obj = new opr1Entities();
            ViewBag.modifiedBy = User.Identity.Name;
            var eid = obj.Schools.Where(w => w.Id == id).FirstOrDefault();
            if (obj == null)
            {
                return RedirectToAction("Index");
            }

            return View(eid);
         
        }
        [HttpPost]
        public ActionResult EditSchool(opr.Models.School schl)
        {
            Models.opr1Entities sub = new opr1Entities();          
            sub.Entry(schl).State = System.Data.Entity.EntityState.Modified;
            try
            {
                sub.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

            }
            ModelState.AddModelError("", "Unable to save changes made to the entity.");
            return View(schl);

        }
    
     
        public ActionResult AddSchool()
        {
     
            ViewBag.ide = User.Identity.GetUserId();
            return View();
        }
        [HttpPost]
        public ActionResult AddSchool(opr.Models.School sch)
        {  
            Models.opr1Entities db = new opr1Entities();
            
            db.Schools.Add(sch);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            Models.opr1Entities sub = new opr1Entities();
            School student_table = sub.Schools.Find(id);
            sub.Schools.Remove(student_table);
            sub.SaveChanges();
            return RedirectToAction("Index");
         
        }

    }
}