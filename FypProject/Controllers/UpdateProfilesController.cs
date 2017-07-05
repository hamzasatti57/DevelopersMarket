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
    [Authorize]
    public class UpdateProfilesController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UpdateProfiles
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            var profile = db.UpdateProfiles.Where(p => p.UserName == userName).ToList();
            return View(db.UpdateProfiles.ToList());
        }
        public ActionResult UpdateMsg()
        {
            return View();
        }
        public ActionResult PublicProfile()
        {
            return View();
        }

        // GET: UpdateProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateProfile updateProfile = db.UpdateProfiles.Find(id);
            if (updateProfile == null)
            {
                return HttpNotFound();
            }
            return View(updateProfile);
        }

        // GET: UpdateProfiles/Createml
        public ActionResult Create()
        {
            return View();
        }

        // POST: UpdateProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(UpdateProfile updateProfiles, HttpPostedFileBase doc)
        {

            if (ModelState.IsValid && doc != null)
            {
                var filename = Path.GetFileName(doc.FileName);
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png")
                {
                    var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Images/", filename));
                    doc.SaveAs(path);
                    updateProfiles.ImageUrl = "~/Content/Images/" + filename;
                    updateProfiles.UserName = User.Identity.Name;
                    db.UpdateProfiles.Add(updateProfiles);
                    db.SaveChanges();
                    return RedirectToAction("UpdateMsg");
                }
                else
                {
                    ModelState.AddModelError("", "Document size must be less then 5MB");
                    return View(updateProfiles);
                }

            }
            ModelState.AddModelError("", "Photo is required");
            return View(updateProfiles);
        }

        //public ActionResult Create([Bind(Include = "DeveloperID,Name,UserName,Email,Location,Phone,Description,Website,ImageUrl")] UpdateProfile updateProfile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.UpdateProfiles.Add(updateProfile);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(updateProfile);
        //}

        // GET: UpdateProfiles/Edit/5


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateProfile updateProfile = db.UpdateProfiles.Find(id);
            if (updateProfile == null)
            {
                return HttpNotFound();
            }
            return View(updateProfile);
        }

        // POST: UpdateProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateProfile updateProfile, string ImageValue, HttpPostedFileBase doc)
        {
            if (ModelState.IsValid && doc != null)
            {
                var filename = Path.GetFileName(doc.FileName);
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png")
                {
                    var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Images/", filename));
                    doc.SaveAs(path);
                    updateProfile.ImageUrl = "~/Content/Images/" + filename;
                    db.Entry(updateProfile).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Document size must be less then 5MB");
                    return View(updateProfile);
                }

            }
            else if (ModelState.IsValid)
            {

                //updateProfile.ImageUrl = ImageValue;
                updateProfile.UserName = User.Identity.Name;
                db.Entry(updateProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "Photo is required");
            return View(updateProfile);
        }

        //public ActionResult Edit([Bind(Include = "DeveloperID,Name,UserName,Email,Location,Phone,Description,Website,ImageUrl")] UpdateProfile updateProfile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(updateProfile).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(updateProfile);
        //}

        // GET: UpdateProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateProfile updateProfile = db.UpdateProfiles.Find(id);
            if (updateProfile == null)
            {
                return HttpNotFound();
            }
            return View(updateProfile);
        }

        // POST: UpdateProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UpdateProfile updateProfile = db.UpdateProfiles.Find(id);
            db.UpdateProfiles.Remove(updateProfile);
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
