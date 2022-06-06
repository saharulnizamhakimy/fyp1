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
    public class tb_acadprogController : Controller
    {
        private fyp1dbEntities db = new fyp1dbEntities();

        // GET: tb_acadprog
        public ActionResult Index()
        {
            return View(db.tb_acadprog.ToList());
        }

        // GET: tb_acadprog/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_acadprog tb_acadprog = db.tb_acadprog.Find(id);
            if (tb_acadprog == null)
            {
                return HttpNotFound();
            }
            return View(tb_acadprog);
        }

        // GET: tb_acadprog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_acadprog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ap_ID,ap_desc")] tb_acadprog tb_acadprog)
        {
            if (ModelState.IsValid)
            {
                db.tb_acadprog.Add(tb_acadprog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_acadprog);
        }

        // GET: tb_acadprog/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_acadprog tb_acadprog = db.tb_acadprog.Find(id);
            if (tb_acadprog == null)
            {
                return HttpNotFound();
            }
            return View(tb_acadprog);
        }

        // POST: tb_acadprog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ap_ID,ap_desc")] tb_acadprog tb_acadprog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_acadprog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_acadprog);
        }

        // GET: tb_acadprog/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_acadprog tb_acadprog = db.tb_acadprog.Find(id);
            if (tb_acadprog == null)
            {
                return HttpNotFound();
            }
            return View(tb_acadprog);
        }

        // POST: tb_acadprog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_acadprog tb_acadprog = db.tb_acadprog.Find(id);
            db.tb_acadprog.Remove(tb_acadprog);
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
