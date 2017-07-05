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
    public class MoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mores
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
            return View(db.Mores.ToList());
        }

        // GET: Mores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            More more = db.Mores.Find(id);
            if (more == null)
            {
                return HttpNotFound();
            }
            return View(more);
        }

        // GET: Mores/Create
        public ActionResult Create()
        {
            More objStudentModel = new More();

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
        // POST: Mores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(More more, HttpPostedFileBase doc)
        {
            if (ModelState.IsValid && doc != null)
            {
                var filename = Path.GetFileName(doc.FileName);
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png")
                {
                    var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Image/", filename));
                    doc.SaveAs(path);
                    more.ImageUrl = "~/Content/Image/" + filename;
                    db.Mores.Add(more);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Document size must be less then 5MB");
                    return View(more);
                }

            }
            ModelState.AddModelError("", "Photo is required");
            return View(more);
        }

        // GET: Mores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            More more = db.Mores.Find(id);
            if (more == null)
            {
                return HttpNotFound();
            }
            return View(more);
        }

        // POST: Mores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            More more = db.Mores.Find(id);
            db.Mores.Remove(more);
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
