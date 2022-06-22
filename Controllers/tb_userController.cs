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
    public class tb_userController : Controller
    {
        private fyp1dbEntities db = new fyp1dbEntities();

        // GET: tb_user
        public ActionResult Index()
        {
            if (@Session["UserType"].ToString() == "1")
            {
                var ID = Session["UserID"];
                var tb_user = db.tb_user.Include(t => t.tb_acadprog).Include(t => t.tb_student).Include(t => t.tb_sv).Include(t => t.tb_usertype).Where(t => t.u_type != 2).Where(t => t.u_type != 1);
                return View(tb_user.ToList());

            }
            else
            {
                var tb_user = db.tb_user.Include(t => t.tb_acadprog).Include(t => t.tb_student).Include(t => t.tb_sv).Include(t => t.tb_usertype);
                return View(tb_user.ToList());
            }
        }
        public ActionResult Index2()
        {
            if (@Session["UserType"].ToString() == "1")
            {
                var ID = Session["UserID"];
                var tb_user = db.tb_user.Include(t => t.tb_acadprog).Include(t => t.tb_student).Include(t => t.tb_sv).Include(t => t.tb_usertype).Where(t => t.u_type == 5);
                return View(tb_user.ToList());

            }
            else
            {
                var tb_user = db.tb_user.Include(t => t.tb_acadprog).Include(t => t.tb_student).Include(t => t.tb_sv).Include(t => t.tb_usertype);
                return View(tb_user.ToList());
            }
        }

        // GET: tb_user/Details/5
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

        // GET: tb_user/Create
        public ActionResult Create()
        {
            ViewBag.u_ID = new SelectList(db.tb_sv, "sv_ID", "sv_ID");
            //ViewBag.u_type = new SelectList(db.tb_usertype, "ut_ID", "ut_desc");
            return View();
        }

        // POST: tb_user/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "u_ID,u_pwd,u_name,u_contact,u_email,u_type,u_acadProgID")] tb_user tb_user)
        {
            if (ModelState.IsValid)
            {
                tb_user.u_type = 3;
                db.tb_user.Add(tb_user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.u_ID = new SelectList(db.tb_sv, "sv_ID", "sv_ID", tb_user.u_ID);
            //ViewBag.u_type = new SelectList(db.tb_usertype, "ut_ID", "ut_desc", tb_user.u_type);
            return View(tb_user);
        }

        // GET: tb_user/Edit/5
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
            ViewBag.u_ID = new SelectList(db.tb_sv, "sv_ID", "sv_ID", tb_user.u_ID);
            ViewBag.u_type = new SelectList(db.tb_usertype, "ut_ID", "ut_desc", tb_user.u_type);
            return View(tb_user);
        }

        // POST: tb_user/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "u_ID,u_pwd,u_name,u_contact,u_email,u_type,u_acadProdID")] tb_user tb_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.u_ID = new SelectList(db.tb_sv, "sv_ID", "sv_ID", tb_user.u_ID);
            ViewBag.u_type = new SelectList(db.tb_usertype, "ut_ID", "ut_desc", tb_user.u_type);
            return View(tb_user);
        }

        // GET: tb_user/Delete/5
        public ActionResult Delete(string id)
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

        // POST: tb_user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_user tb_user = db.tb_user.Find(id);
            db.tb_user.Remove(tb_user);
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

        //create student record on user table then redirect to edit student from student table
        public ActionResult CreateStudent()
        {
            //ViewBag.u_ID = new SelectList(db.tb_committee, "cmt_ID", "cmt_acadprogID");
            //ViewBag.u_ID = new SelectList(db.tb_student, "s_id", "s_acadprogID");
            //ViewBag.u_acadProgID = new SelectList(db.tb_acadprog, "ap_ID", "ap_ID");
            var clients = db.tb_acadprog
                .Select(s => new
                {
                    Text = s.ap_ID + " - " + s.ap_desc,
                    Value = s.ap_ID
                })
                .ToList();

            ViewBag.u_acadProgID = new SelectList(clients, "Value", "Text");
            ViewBag.u_acadProgID = new SelectList(clients, "Value", "Text");
            return View();
        }

        // POST: tb_user/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStudent([Bind(Include = "u_ID,u_pwd,u_name,u_contact,u_email,u_type,u_acadProgID")] tb_user tb_user)
        {
            if (ModelState.IsValid)
            {
                tb_user.u_type = 2;
                db.tb_user.Add(tb_user);
                db.SaveChanges();
                
                return RedirectToAction("Index", "Login");
            }

            //ViewBag.u_ID = new SelectList(db.tb_committee, "cmt_ID", "cmt_acadprogID", tb_user.u_ID);
            //ViewBag.u_ID = new SelectList(db.tb_student, "s_id", "s_acadprogID", tb_user.u_ID);
            var clients = db.tb_acadprog
                .Select(s => new
                {
                    Text = s.ap_ID + " - " + s.ap_desc,
                    Value = s.ap_ID
                })
                .ToList();

            ViewBag.u_acadProgID = new SelectList(clients, "Value", "Text", tb_user.u_acadProgID);
            //ViewBag.u_acadProgID = new SelectList(db.tb_acadprog, "ap_ID", "ap_ID", tb_user.u_acadProgID);
            return View(tb_user);
        }


        public ActionResult addCmt(string id)
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
            ViewBag.u_ID = new SelectList(db.tb_user, "u_ID", "u_name", tb_user.u_ID);

            var clients = db.tb_user.Where(t=>t.u_type == 3)
                .Select(s => new
                {
                    Text = s.u_ID + " - " + s.u_name,
                    Value = s.u_ID
                })
                .ToList();

            ViewBag.u_ID = new SelectList(clients, "Value", "Text", tb_user.u_ID);
            return View(tb_user);
        }

        // POST: tb_student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addCmt([Bind(Include = "u_ID,u_pwd,u_name,u_contact,u_email,u_type,u_acadProgID")] tb_user tb_user)
        {
            if (ModelState.IsValid)
            {
                tb_user.u_type = 5;
                db.Entry(tb_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s_svID = new SelectList(db.tb_user, "sv_ID", "sv_ID", tb_user.u_ID);
            ViewBag.s_id = new SelectList(db.tb_user, "u_ID", "u_name", tb_user.u_ID);
            return View(tb_user);
        }
    }
}
