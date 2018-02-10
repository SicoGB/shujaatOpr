using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using opr.Models;

namespace opr.Controllers
{
    [Authorize]
    public class SectionsController : Controller
    {
        // GET: Sections
        public ActionResult Index()
        {
            Section model = new Section();
            model.IsDeleted = true;
            model.IsActive = true;
            //model.UserId= User.Identity.Name;
            //ViewBag.InitialValue = "initialvalue";
            //ViewData["ee"] = User.Identity.Name;
            ViewBag.InitialValue = User.Identity.Name;
            ViewBag.DateTime = DateTime.Now;

            return View(new Section());
        }
        [HttpPost]
        public ActionResult Index(opr.Models.Section model)

        {
            model.IsDeleted = true;
            model.IsActive = true;

            opr.Models.oprEntities  db = new oprEntities();
            db.Sections.Add(model);
            db.SaveChanges();

            return View(new Section());
        }
        public ActionResult SectionDetail()
        {
            Models.oprEntities db = new oprEntities();
            IList<Models.Section> model = new List<Section>();
            model = db.Sections.ToList();

            return View(model);

        }

        //public ActionResult DeleteData(int id)
        //{
        //    Models.oprEntities db = new oprEntities();
        //    Section Sectiondt = db.Sections.Find(id);

        //    db.Sections.Remove(Sectiondt);
        //    db.SaveChanges();
        //    return RedirectToAction("SectionDetail");
        //}

        //public ActionResult DeleteData(int id)
        //{
        //    Models.oprEntities db = new oprEntities();
        //    Section Sectiondt = db.Sections.Find(id);
        //    return View(Sectiondt);

        //    //var user = new User() { Id = userId, Password = password };
        //    //using (var db = new MyEfContextName())
        //    //{
        //    //    db.Users.Attach(user);
        //    //    db.Entry(user).Property(x => x.Password).IsModified = true;
        //    //    db.SaveChanges();
        //    //}
        //    //return RedirectToAction("Index");
        //}

        public ActionResult DeleteData(int id)
        {
            Section model = new Section();
            model.IsDeleted = true;
            Models.oprEntities db = new oprEntities();
            Section Sectiondt = db.Sections.Find(id);
            return View(Sectiondt);
        }

        [HttpPost]
        public ActionResult DeleteData(opr.Models.Section model)
        {
            Models.oprEntities db = new oprEntities();
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            try
            {

                db.SaveChanges();
                return RedirectToAction("SectionDetail");
            }
            catch
            {

            }
            ModelState.AddModelError("", "Unable to save changes");
            return View(model);
        }

        public ActionResult EditView(int id)
        {
            Models.oprEntities db = new oprEntities();
            Section Sectiondt = db.Sections.Find(id);
            return View(Sectiondt);
        }
        [HttpPost]
        public ActionResult EditView(opr.Models.Section model)
        {
            Models.oprEntities db = new oprEntities();
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            try
            {

                db.SaveChanges();
                return RedirectToAction("SectionDetail");
            }
            catch
            {

            }
            ModelState.AddModelError("", "Unable to save changes");
            return View(model);
        }
    }
}