using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using opr.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace opr.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
       
        // GET: Group
        public ActionResult Index()
        {


            oprEntities dbgrp = new oprEntities();
            List<Group> listOfGroup = new List<Group>();
            var saveGroup = dbgrp.Groups.ToList();
            return View(saveGroup);
        }
       
         public ActionResult AddGroup()
        {
            ViewBag.date = DateTime.Now;
            ViewBag.ids = User.Identity.GetUserId();
            ViewBag.name = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public ActionResult AddGroup(opr.Models.Group mod)
        {
            oprEntities dbgrp = new oprEntities();
            dbgrp.Groups.Add(mod);
            dbgrp.SaveChanges();


            return View();
        }
        public ActionResult DeleteGroup(int Id)
        {
            oprEntities obj = new oprEntities();
            Group grp = obj.Groups.Find(Id);
            obj.Groups.Remove(grp);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IsDelete(int Id)
        {
            oprEntities db = new oprEntities();
           Group classdt = db.Groups.Find(Id);
            classdt.IsDeleted = true;
            db.Entry(classdt).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
       public ActionResult EditGroup(int Id)
        {
        ViewBag.date = DateTime.Now;
        ViewBag.ids = User.Identity.GetUserId();
            ViewBag.name = User.Identity.Name;
            oprEntities grdata = new oprEntities();
             Group edata = grdata.Groups.Find(Id);
            return View(edata);


        }
        [HttpPost]
        public ActionResult EditGroup(opr.Models.Group grp)
        {

            oprEntities groupData = new oprEntities();

            groupData.Entry(grp).State = System.Data.Entity.EntityState.Modified;
            try
            {
                groupData.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

            }
            ModelState.AddModelError("", "Unable to save changes made to the entity.");
            return View(grp);
        }
    }
}