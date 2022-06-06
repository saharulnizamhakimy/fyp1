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
    public class tb_committeeController : Controller
    {
        private fyp1dbEntities db = new fyp1dbEntities();

        // GET: tb_committee
        public ActionResult Index()
        {
            var tb_committee = db.tb_committee.Include(t => t.tb_acadprog).Include(t => t.tb_user);
            return View(tb_committee.ToList());
        }

        // GET: tb_committee/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_committee tb_committee = db.tb_committee.Find(id);
            if (tb_committee == null)
            {
                return HttpNotFound();
            }
            return View(tb_committee);
        }

        // GET: tb_committee/Create
        public ActionResult Create()
        {
            ViewBag.cmt_acadprogID = new SelectList(db.tb_acadprog, "ap_ID", "ap_desc");
            ViewBag.cmt_ID = new SelectList(db.tb_user, "u_ID", "u_pwd");
            return View();
        }

        // POST: tb_committee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cmt_ID,cmt_acadprogID")] tb_committee tb_committee)
        {
            if (ModelState.IsValid)
            {
                db.tb_committee.Add(tb_committee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cmt_acadprogID = new SelectList(db.tb_acadprog, "ap_ID", "ap_desc", tb_committee.cmt_acadprogID);
            ViewBag.cmt_ID = new SelectList(db.tb_user, "u_ID", "u_pwd", tb_committee.cmt_ID);
            return View(tb_committee);
        }

        // GET: tb_committee/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_committee tb_committee = db.tb_committee.Find(id);
            if (tb_committee == null)
            {
                return HttpNotFound();
            }
            ViewBag.cmt_acadprogID = new SelectList(db.tb_acadprog, "ap_ID", "ap_desc", tb_committee.cmt_acadprogID);
            ViewBag.cmt_ID = new SelectList(db.tb_user, "u_ID", "u_pwd", tb_committee.cmt_ID);
            return View(tb_committee);
        }

        // POST: tb_committee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cmt_ID,cmt_acadprogID")] tb_committee tb_committee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_committee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cmt_acadprogID = new SelectList(db.tb_acadprog, "ap_ID", "ap_desc", tb_committee.cmt_acadprogID);
            ViewBag.cmt_ID = new SelectList(db.tb_user, "u_ID", "u_pwd", tb_committee.cmt_ID);
            return View(tb_committee);
        }

        // GET: tb_committee/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_committee tb_committee = db.tb_committee.Find(id);
            if (tb_committee == null)
            {
                return HttpNotFound();
            }
            return View(tb_committee);
        }

        // POST: tb_committee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_committee tb_committee = db.tb_committee.Find(id);
            db.tb_committee.Remove(tb_committee);
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
