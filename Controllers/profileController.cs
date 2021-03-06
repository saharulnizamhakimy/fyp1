using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fyp1.Models;

namespace fyp1.Controllers
{
    public class profileController : Controller
    {
        private fyp1dbEntities db = new fyp1dbEntities();

        // GET: profile
        public ActionResult Index()
        {
            var tb_user = db.tb_user.Include(t => t.tb_student).Include(t => t.tb_sv).Include(t => t.tb_usertype);
            return View(tb_user.ToList());
        }

        // GET: profile/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_user tb_user = db.tb_user.Find(id);
            if (tb_user == null)
            {
                return HttpNotFound();
            }
            return View(tb_user);
        }

        // GET: profile/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_user tb_user = db.tb_user.Find(id);
            if (tb_user == null)
            {
                return HttpNotFound();
            }
            ViewBag.u_ID = new SelectList(db.tb_student, "s_id", "s_acadprogID", tb_user.u_ID);
            ViewBag.u_ID = new SelectList(db.tb_sv, "sv_ID", "sv_ID", tb_user.u_ID);
            ViewBag.u_type = new SelectList(db.tb_usertype, "ut_ID", "ut_desc", tb_user.u_type);
            return View(tb_user);
        }

        // POST: profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "u_ID,u_pwd,u_name,u_contact,u_email,u_type")] tb_user tb_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "profile", new {id=Session["UserID"]});
            }
            ViewBag.u_ID = new SelectList(db.tb_student, "s_id", "s_acadprogID", tb_user.u_ID);
            ViewBag.u_ID = new SelectList(db.tb_sv, "sv_ID", "sv_ID", tb_user.u_ID);
            ViewBag.u_type = new SelectList(db.tb_usertype, "ut_ID", "ut_desc", tb_user.u_type);
            return View(tb_user);
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
