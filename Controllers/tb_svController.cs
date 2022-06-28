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
    public class tb_svController : Controller
    {
        private fyp1dbEntities db = new fyp1dbEntities();

        // GET: tb_sv
        public ActionResult Index()
        {
            var ID = Session["AcadProg"].ToString();
            var tb_sv = db.tb_sv.Include(t => t.tb_domain).Include(t=>t.tb_user).Where(t=>t.tb_user.u_acadProgID.ToString()==ID);
            return View(tb_sv.ToList());

            //var tb_sv = db.tb_sv.Include(t => t.tb_domain).Include(t => t.tb_user);
            //return View(tb_sv.ToList());
        }

        // GET: tb_sv/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sv tb_sv = db.tb_sv.Find(id);
            if (tb_sv == null)
            {
                return HttpNotFound();
            }
            return View(tb_sv);
        }

        // GET: tb_sv/Create
        public ActionResult Create()
        {
            ViewBag.sv_domainID = new SelectList(db.tb_domain, "d_ID", "d_desc");

            //var clients = db.tb_user.Include(t=>t.tb_sv).Where(t => t.u_type != 3 && t.u_type != 1 && t.u_type != 2)
            //    .Select(s => new
            //    {
            //        Text = s.tb_sv.sv_ID + " - " + s.tb_sv.tb_user.u_name,
            //        Value = s.tb_sv.sv_ID
            //    })
            //    .ToList();

            //ViewBag.sv_ID = new SelectList(clients, "Value", "Text");

            ViewBag.sv_ID = new SelectList(db.tb_user, "u_ID", "u_name");
            return View();
        }

        // POST: tb_sv/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sv_ID,sv_domainID")] tb_sv tb_sv)
        {
            if (ModelState.IsValid)
            {
                db.tb_sv.Add(tb_sv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sv_domainID = new SelectList(db.tb_domain, "d_ID", "d_desc", tb_sv.sv_domainID);
            ViewBag.sv_ID = new SelectList(db.tb_user, "u_ID", "u_name", tb_sv.sv_ID);
            return View(tb_sv);
        }

        // GET: tb_sv/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sv tb_sv = db.tb_sv.Find(id);
            if (tb_sv == null)
            {
                return HttpNotFound();
            }
            ViewBag.sv_domainID = new SelectList(db.tb_domain, "d_ID", "d_desc", tb_sv.sv_domainID);
            ViewBag.sv_ID = new SelectList(db.tb_user, "u_ID", "u_name", tb_sv.sv_ID);
            return View(tb_sv);
        }

        // POST: tb_sv/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sv_ID,sv_domainID")] tb_sv tb_sv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_sv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sv_domainID = new SelectList(db.tb_domain, "d_ID", "d_desc", tb_sv.sv_domainID);
            ViewBag.sv_ID = new SelectList(db.tb_user, "u_ID", "u_name", tb_sv.sv_ID);
            return View(tb_sv);
        }

        // GET: tb_sv/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sv tb_sv = db.tb_sv.Find(id);
            if (tb_sv == null)
            {
                return HttpNotFound();
            }
            return View(tb_sv);
        }

        // POST: tb_sv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_sv tb_sv = db.tb_sv.Find(id);
            db.tb_sv.Remove(tb_sv);
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
