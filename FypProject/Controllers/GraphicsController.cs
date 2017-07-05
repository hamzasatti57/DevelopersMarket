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
using FypProject.Services;

namespace FypProject.Controllers
{
    public class GraphicsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly StoreService _store;
        public GraphicsController() : this(new StoreService()) { }
        public GraphicsController(StoreService service)
        {
            _store = service;
        }

        // GET: Graphics
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
            return View(db.Graphics.ToList());
        }

        // GET: Graphics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graphic graphic = db.Graphics.Find(id);
            if (graphic == null)
            {
                return HttpNotFound();
            }
            return View(graphic);
        }

        // GET: Graphics/Create
        public ActionResult Create()
        {
            Graphic objStudentModel = new Graphic();

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

        // POST: Graphics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Graphic graphic, HttpPostedFileBase doc)
        {
            if (ModelState.IsValid && doc != null)
            {
                var filename = Path.GetFileName(doc.FileName);
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png")
                {
                    var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Image/", filename));
                    doc.SaveAs(path);
                    graphic.ImageUrl = "~/Content/Image/" + filename;
                    db.Graphics.Add(graphic);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Document size must be less then 5MB");
                    return View(graphic);
                }

            }
            ModelState.AddModelError("", "Photo is required");
            return View(graphic);
        }
        // GET: Textures/Edit/5
       
        // POST: Graphics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
     

        // GET: Graphics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graphic graphic = db.Graphics.Find(id);
            if (graphic == null)
            {
                return HttpNotFound();
            }
            return View(graphic);
        }

        // POST: Graphics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Graphic graphic = db.Graphics.Find(id);
            db.Graphics.Remove(graphic);
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
