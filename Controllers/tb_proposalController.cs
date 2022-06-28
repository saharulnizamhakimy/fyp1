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
            if (@Session["UserType"].ToString() == "2")
            {
                var ID = Session["UserID"].ToString();
                var tb_proposal = db.tb_proposal.Include(t => t.tb_domain).Include(t => t.tb_status).Include(t => t.tb_student).Include(t => t.tb_user).Where(t => t.p_studentID == ID);
                return View(tb_proposal.ToList());
            }
            if (@Session["UserType"].ToString() == "5")
            {
                var ID = Session["AcadProg"].ToString();
                var tb_proposal = db.tb_proposal.Include(t => t.tb_domain).Include(t => t.tb_status).Include(t => t.tb_student).Include(t => t.tb_user).Where(x => x.tb_student.tb_user.u_acadProgID.ToString() == ID);
                return View(tb_proposal.ToList());
            }
            else
            {
                var tb_proposal = db.tb_proposal.FirstOrDefault();
                var ID2 = Session["UserID"].ToString();
                var tb_proposal1 = db.tb_proposal.Include(t => t.tb_domain).Include(t => t.tb_status).Include(t => t.tb_student).Include(t => t.tb_user).Where(s => s.tb_student.s_svID.ToString() == ID2);
                return View(tb_proposal1.ToList());
            }

        }

        public ActionResult Index2()
        {
            var tb_proposal = db.tb_proposal.FirstOrDefault();
            var ID2 = Session["UserID"].ToString();
            var tb_proposal1 = db.tb_proposal.Include(t => t.tb_domain).Include(t => t.tb_status).Include(t => t.tb_student).Include(t => t.tb_user).Where(s=>s.p_ev1ID.ToString() == ID2 || s.p_ev2ID.ToString() == ID2);
            return View(tb_proposal1.ToList());
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
            ViewBag.p_ev1ID = new SelectList(db.tb_user, "u_ID", "u_ID");
            return View();
        }

        // POST: tb_proposal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "p_ID,p_studentID,p_semester,p_acadsession,p_title,p_domain,p_status,p_ev1ID,p_ev2ID,p_ev1comment,p_ev2comment,p_svcomment,p_bgNsol,p_obj,p_scope,p_softreq,p_hardreq,p_techreq,p_netreq,p_secreq,p_area,p_idea")] tb_proposal tb_proposal)
        {
            if (ModelState.IsValid)
            {
                tb_proposal.p_studentID = Session["UserID"].ToString();
                tb_proposal.p_status = 1;
                db.tb_proposal.Add(tb_proposal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.p_domain = new SelectList(db.tb_domain, "d_ID", "d_desc", tb_proposal.p_domain);
            ViewBag.p_status = new SelectList(db.tb_status, "st_ID", "st_desc", tb_proposal.p_status);
            ViewBag.p_ev1ID = new SelectList(db.tb_user, "u_ID", "u_ID", tb_proposal.p_ev1ID);
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
            var ID = Session["AcadProg"].ToString();

            var ev1 = db.tb_user.Where(r => r.u_type == 3).Where(s => s.u_ID != tb_proposal.tb_student.s_svID).Where(s => s.tb_sv.sv_domainID == tb_proposal.p_domain).Where(t => t.tb_sv.tb_user.u_acadProgID == ID)
               .Select(s => new
               {
                   Text = s.u_ID + " - " + s.u_name,
                   Value = s.u_ID
               })
               .ToList();
            ViewBag.p_ev1ID = new SelectList(ev1, "Value", "Text", tb_proposal.p_ev1ID);

            var ev2 = db.tb_user.Where(r => r.u_type == 3).Where(s => s.u_ID != tb_proposal.tb_student.s_svID).Where(s => s.tb_sv.sv_domainID == tb_proposal.p_domain).Where(t => t.tb_sv.tb_user.u_acadProgID == ID)
               .Select(s => new
               {
                   Text1 = s.u_ID + " - " + s.u_name,
                   Value1 = s.u_ID
               })
               .ToList();
            ViewBag.p_ev2ID = new SelectList(ev2, "Value1", "Text1", tb_proposal.p_ev2ID);
            return View(tb_proposal);
        }

        // POST: tb_proposal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "p_ID,p_studentID,p_semester,p_acadsession,p_title,p_domain,p_status,p_ev1ID,p_ev2ID,p_ev1comment,p_ev2comment,p_svcomment,p_bgNsol,p_obj,p_scope,p_softreq,p_hardreq,p_techreq,p_netreq,p_secreq,p_area,p_idea")] tb_proposal tb_proposal)
        {
            if (ModelState.IsValid)
            {
                if (Session["UserType"].ToString()=="2")
                {
                    tb_proposal.p_status = 1;
                }
                db.Entry(tb_proposal).State = EntityState.Modified;
                db.SaveChanges();
                if (Session["UserID"].ToString() == tb_proposal.p_ev1ID || Session["UserID"].ToString() == tb_proposal.p_ev2ID)
                { 
                    return RedirectToAction("Index2"); 
                }
                return RedirectToAction("Index");
            }
            ViewBag.p_domain = new SelectList(db.tb_domain, "d_ID", "d_desc", tb_proposal.p_domain);
            ViewBag.p_status = new SelectList(db.tb_status, "st_ID", "st_desc", tb_proposal.p_status);
            ViewBag.p_ev1ID = new SelectList(db.tb_user, "u_ID", "u_ID", tb_proposal.p_ev1ID);
            ViewBag.p_ev2ID = new SelectList(db.tb_user, "u_ID", "u_ID", tb_proposal.p_ev2ID);
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
