using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FypProject.Models;
using System.IO;
using System.Web.Hosting;

namespace FypProject.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projects
        //public ActionResult Index()
        //{
        //    return View(db.Projects.ToList());
        //}
        public ActionResult Index(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }
            // redirect back to the index action to show the form once again
            //return RedirectToAction("Index");
            return View(db.Projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create

        public ActionResult Create()
        {
            Project objStudentModel = new Project();

            List<SelectListItem> names = new List<SelectListItem>();

            names.Add(new SelectListItem { Text = "Chrome", Value = "1" });
            names.Add(new SelectListItem { Text = "Firefox", Value = "2" });
            names.Add(new SelectListItem { Text = "Safari", Value = "3" });
            names.Add(new SelectListItem { Text = "Opera", Value = "4" });
            names.Add(new SelectListItem { Text = "Edge", Value = "5" });
            names.Add(new SelectListItem { Text = "IE6", Value = "6" });
            names.Add(new SelectListItem { Text = "IE7", Value = "7" });
            names.Add(new SelectListItem { Text = "IE8", Value = "8" });
            names.Add(new SelectListItem { Text = "IE9", Value = "9" });
            names.Add(new SelectListItem { Text = "IE10", Value = "10" });
            names.Add(new SelectListItem { Text = "IE11", Value = "11" });
            objStudentModel.CompatibleBrowsers = names;

            return View(objStudentModel);
        }
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project projects, HttpPostedFileBase doc)
        {
            if (ModelState.IsValid && doc != null)
            {
                var filename = Path.GetFileName(doc.FileName);
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png")
                {
                    var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Image/", filename));
                    doc.SaveAs(path);
                    projects.ImageUrl = "~/Content/Image/" + filename;
                    db.Projects.Add(projects);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Document size must be less then 5MB");
                    return View(projects);
                }

            }
            ModelState.AddModelError("", "Photo is required");
            return View(projects);
        }
        //public ActionResult Create([Bind(Include = "ID,ItemLevel,Name,Description,File,ImageUrl,Layered,Layout,HighResolution,LiveDemo,VideoUrl,Tags,Price,Comment,License")] Project project)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Projects.Add(project);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(project);
        //}

     
        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
