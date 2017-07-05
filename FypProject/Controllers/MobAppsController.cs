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
    public class MobAppsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MobApps
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
            return View(db.MobApps.ToList());
        }

        // GET: MobApps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobApp mobApp = db.MobApps.Find(id);
            if (mobApp == null)
            {
                return HttpNotFound();
            }
            return View(mobApp);
        }

        // GET: MobApps/Create
        public ActionResult Create()
        {
            MobApp objStudentModel = new MobApp();

            List<SelectListItem> names = new List<SelectListItem>();

            names.Add(new SelectListItem { Text = "Social", Value = "1" });
            names.Add(new SelectListItem { Text = "Gamming", Value = "2" });
            names.Add(new SelectListItem { Text = "Sharing", Value = "3" });
            names.Add(new SelectListItem { Text = "Education", Value = "4" });
            names.Add(new SelectListItem { Text = "Business", Value = "5" });
            names.Add(new SelectListItem { Text = "Medical", Value = "7" });
            names.Add(new SelectListItem { Text = "Shopping", Value = "8" });
            names.Add(new SelectListItem { Text = "Sports", Value = "9" });
            names.Add(new SelectListItem { Text = "Weather", Value = "10" });
            names.Add(new SelectListItem { Text = "Events", Value = "11" });

            objStudentModel.CompatibleBrowsers = names;

            return View(objStudentModel);
        }

        // POST: MobApps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MobApp mobapp, HttpPostedFileBase doc)
        {
            if (ModelState.IsValid && doc != null)
            {
                var filename = Path.GetFileName(doc.FileName);
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png")
                {
                    var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Image/", filename));
                    doc.SaveAs(path);
                    mobapp.ImageUrl = "~/Content/Image/" + filename;
                    db.MobApps.Add(mobapp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Document size must be less then 5MB");
                    return View(mobapp);
                }

            }
            ModelState.AddModelError("", "Photo is required");
            return View(mobapp);
        }

        // GET: MobApps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobApp mobApp = db.MobApps.Find(id);
            if (mobApp == null)
            {
                return HttpNotFound();
            }
            return View(mobApp);
        }

        // POST: MobApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MobApp mobApp = db.MobApps.Find(id);
            db.MobApps.Remove(mobApp);
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
