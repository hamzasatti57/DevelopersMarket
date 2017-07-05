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
    public class ThemesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Themes
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
            return View(db.Themes.ToList());
        }

        // GET: Themes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }
        // GET: Themes/Create
        public ActionResult Create()
        {
            Theme objStudentModel = new Theme();

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

        // POST: Themes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ThemeID,ItemLevel,Category,Name,Description,File,ImageUrl,Layered,Layout,HighResolution,LiveDemo,VideoUrl,Tags,Price,Comment,License")] Theme theme)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Themes.Add(theme);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(theme);
        //}

     
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Theme themes, HttpPostedFileBase doc)
        {
            if (ModelState.IsValid && doc != null)
            {
                var filename = Path.GetFileName(doc.FileName);
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png")
                {
                    var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Image/", filename));
                    doc.SaveAs(path);
                    themes.ImageUrl = "~/Content/Image/" + filename;
                    db.Themes.Add(themes);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Document size must be less then 5MB");
                    return View(themes);
                }

            }
            ModelState.AddModelError("", "Photo is required");
            return View(themes);
        }
        

        // GET: Themes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        // POST: Themes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theme theme = db.Themes.Find(id);
            db.Themes.Remove(theme);
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
