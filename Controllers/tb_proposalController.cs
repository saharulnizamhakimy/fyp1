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
    public class tb_proposalController : Controller
    {
        private fyp1dbEntities db = new fyp1dbEntities();

        // GET: tb_proposal
        public ActionResult Index()
        {
            var tb_proposal = db.tb_proposal.Include(t => t.tb_domain).Include(t => t.tb_status).Include(t => t.tb_user);
            return View(tb_proposal.ToList());
        }

        // GET: tb_proposal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_proposal tb_proposal = db.tb_proposal.Find(id);
            if (tb_proposal == null)
            {
                return HttpNotFound();
            }
            return View(tb_proposal);
        }

        // GET: tb_proposal/Create
        public ActionResult Create()
        {
            ViewBag.p_domain = new SelectList(db.tb_domain, "d_ID", "d_desc");
            ViewBag.p_status = new SelectList(db.tb_status, "st_ID", "st_desc");
            ViewBag.p_ev1ID = new SelectList(db.tb_user, "u_ID", "u_pwd");
            ViewBag.p_ev2ID = new SelectList(db.tb_user, "u_ID", "u_pwd");
            return View();
        }

        // POST: tb_proposal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "p_ID,p_studentID,p_semester,p_acadsession,p_title,p_domain,p_detail,p_status,p_ev1ID,p_ev2ID,p_ev1comment,p_ev2comment,p_svcomment")] tb_proposal tb_proposal)
        {
            if (ModelState.IsValid)
            {
                db.tb_proposal.Add(tb_proposal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.p_domain = new SelectList(db.tb_domain, "d_ID", "d_desc", tb_proposal.p_domain);
            ViewBag.p_status = new SelectList(db.tb_status, "st_ID", "st_desc", tb_proposal.p_status);
            ViewBag.p_ev1ID = new SelectList(db.tb_user, "u_ID", "u_pwd", tb_proposal.p_ev1ID);
            ViewBag.p_ev2ID = new SelectList(db.tb_user, "u_ID", "u_pwd", tb_proposal.p_ev2ID);
            return View(tb_proposal);
        }

        // GET: tb_proposal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_proposal tb_proposal = db.tb_proposal.Find(id);
            if (tb_proposal == null)
            {
                return HttpNotFound();
            }
            ViewBag.p_domain = new SelectList(db.tb_domain, "d_ID", "d_desc", tb_proposal.p_domain);
            ViewBag.p_status = new SelectList(db.tb_status, "st_ID", "st_desc", tb_proposal.p_status);
            ViewBag.p_ev1ID = new SelectList(db.tb_user, "u_ID", "u_pwd", tb_proposal.p_ev1ID);
            ViewBag.p_ev2ID = new SelectList(db.tb_user, "u_ID", "u_pwd", tb_proposal.p_ev2ID);
            return View(tb_proposal);
        }

        // POST: tb_proposal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "p_ID,p_studentID,p_semester,p_acadsession,p_title,p_domain,p_detail,p_status,p_ev1ID,p_ev2ID,p_ev1comment,p_ev2comment,p_svcomment")] tb_proposal tb_proposal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_proposal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.p_domain = new SelectList(db.tb_domain, "d_ID", "d_desc", tb_proposal.p_domain);
            ViewBag.p_status = new SelectList(db.tb_status, "st_ID", "st_desc", tb_proposal.p_status);
            ViewBag.p_ev1ID = new SelectList(db.tb_user, "u_ID", "u_pwd", tb_proposal.p_ev1ID);
            ViewBag.p_ev2ID = new SelectList(db.tb_user, "u_ID", "u_pwd", tb_proposal.p_ev2ID);
            return View(tb_proposal);
        }

        // GET: tb_proposal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_proposal tb_proposal = db.tb_proposal.Find(id);
            if (tb_proposal == null)
            {
                return HttpNotFound();
            }
            return View(tb_proposal);
        }

        // POST: tb_proposal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_proposal tb_proposal = db.tb_proposal.Find(id);
            db.tb_proposal.Remove(tb_proposal);
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
