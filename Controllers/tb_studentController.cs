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
    public class tb_studentController : Controller
    {
        private fyp1dbEntities db = new fyp1dbEntities();

        // GET: tb_student
        public ActionResult Index()
        {
            var tb_student = db.tb_student.Include(t => t.tb_acadprog).Include(t => t.tb_proposal).Include(t => t.tb_sv).Include(t => t.tb_user);
            return View(tb_student.ToList());
        }

        // GET: tb_student/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_student tb_student = db.tb_student.Find(id);
            if (tb_student == null)
            {
                return HttpNotFound();
            }
            return View(tb_student);
        }

        // GET: tb_student/Create
        public ActionResult Create()
        {
            ViewBag.s_acadprogID = new SelectList(db.tb_acadprog, "ap_ID", "ap_desc");
            ViewBag.s_proposalD = new SelectList(db.tb_proposal, "p_ID", "p_studentID");
            ViewBag.s_svID = new SelectList(db.tb_sv, "sv_ID", "sv_ID");
            ViewBag.s_id = new SelectList(db.tb_user, "u_ID", "u_name");
            var clients = db.tb_sv
                .Select(s => new
                {
                    Text = s.sv_ID + " - " + s.tb_user.u_name,
                    Value = s.sv_ID
                })
                .ToList();

            ViewBag.s_svID = new SelectList(clients, "Value", "Text");
            return View();
        }

        // POST: tb_student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "s_id,s_acadprogID,s_svID,s_proposalD")] tb_student tb_student)
        {
            if (ModelState.IsValid)
            {
                db.tb_student.Add(tb_student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.s_acadprogID = new SelectList(db.tb_acadprog, "ap_ID", "ap_desc", tb_student.s_acadprogID);
            ViewBag.s_proposalD = new SelectList(db.tb_proposal, "p_ID", "p_studentID", tb_student.s_proposalD);
            ViewBag.s_svID = new SelectList(db.tb_sv, "sv_ID", "sv_ID", tb_student.s_svID);
            ViewBag.s_id = new SelectList(db.tb_user, "u_ID", "u_name", tb_student.s_id);
            return View(tb_student);
        }

        // GET: tb_student/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_student tb_student = db.tb_student.Find(id);
            if (tb_student == null)
            {
                return HttpNotFound();
            }
            ViewBag.s_acadprogID = new SelectList(db.tb_acadprog, "ap_ID", "ap_desc", tb_student.s_acadprogID);
            ViewBag.s_proposalD = new SelectList(db.tb_proposal, "p_ID", "p_studentID", tb_student.s_proposalD);
            ViewBag.s_id = new SelectList(db.tb_user, "u_ID", "u_name", tb_student.s_id);

            var clients = db.tb_sv
                .Select(s => new
                {
                    Text = s.sv_ID + " - " + s.tb_user.u_name,
                    Value = s.sv_ID
                })
                .ToList();

            ViewBag.s_svID = new SelectList(clients, "Value", "Text", tb_student.s_svID);
            return View(tb_student);
        }

        // POST: tb_student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "s_id,s_acadprogID,s_svID,s_proposalD")] tb_student tb_student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s_acadprogID = new SelectList(db.tb_acadprog, "ap_ID", "ap_desc", tb_student.s_acadprogID);
            ViewBag.s_proposalD = new SelectList(db.tb_proposal, "p_ID", "p_studentID", tb_student.s_proposalD);
            ViewBag.s_svID = new SelectList(db.tb_sv, "sv_ID", "sv_ID", tb_student.s_svID);
            ViewBag.s_id = new SelectList(db.tb_user, "u_ID", "u_name", tb_student.s_id);
            return View(tb_student);
        }

        // GET: tb_student/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_student tb_student = db.tb_student.Find(id);
            if (tb_student == null)
            {
                return HttpNotFound();
            }
            return View(tb_student);
        }

        // POST: tb_student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_student tb_student = db.tb_student.Find(id);
            db.tb_student.Remove(tb_student);
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



        // GET: tb_student/Edit/5
        public ActionResult selectSV(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_student tb_student = db.tb_student.Find(id);
            if (tb_student == null)
            {
                return HttpNotFound();
            }
            ViewBag.s_acadprogID = new SelectList(db.tb_acadprog, "ap_ID", "ap_desc", tb_student.s_acadprogID);
            ViewBag.s_proposalD = new SelectList(db.tb_proposal, "p_ID", "p_studentID", tb_student.s_proposalD);
            ViewBag.s_id = new SelectList(db.tb_user, "u_ID", "u_name", tb_student.s_id);

            var clients = db.tb_sv
                .Select(s => new
                {
                    Text = s.sv_ID + " - " + s.tb_user.u_name,
                    Value = s.sv_ID
                })
                .ToList();

            ViewBag.s_svID = new SelectList(clients, "Value", "Text", tb_student.s_svID);
            return View(tb_student);
        }

        // POST: tb_student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult selectSV([Bind(Include = "s_id,s_acadprogID,s_svID,s_proposalD")] tb_student tb_student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s_acadprogID = new SelectList(db.tb_acadprog, "ap_ID", "ap_desc", tb_student.s_acadprogID);
            ViewBag.s_proposalD = new SelectList(db.tb_proposal, "p_ID", "p_studentID", tb_student.s_proposalD);
            ViewBag.s_svID = new SelectList(db.tb_sv, "sv_ID", "sv_ID", tb_student.s_svID);
            ViewBag.s_id = new SelectList(db.tb_user, "u_ID", "u_name", tb_student.s_id);
            return View(tb_student);
        }
    }
}
