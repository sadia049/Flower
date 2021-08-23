using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlowerBouquet.Data;
using FlowerBouquet.Models;

namespace FlowerBouquet.Controllers
{
    public class MemberRolesController : Controller
    {
        private FlowerBouquetContext db = new FlowerBouquetContext();

        // GET: MemberRoles
        public ActionResult Index()
        {
            var memberRoles = db.MemberRoles.Include(m => m.Members).Include(m => m.Roles);
            return View(memberRoles.ToList());
        }

        // GET: MemberRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberRole memberRole = db.MemberRoles.Find(id);
            if (memberRole == null)
            {
                return HttpNotFound();
            }
            return View(memberRole);
        }

        // GET: MemberRoles/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "F_name");
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }

        // POST: MemberRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberRoleID,MemberID,RoleID")] MemberRole memberRole)
        {
            if (ModelState.IsValid)
            {
                db.MemberRoles.Add(memberRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "F_name", memberRole.MemberID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", memberRole.RoleID);
            return View(memberRole);
        }

        // GET: MemberRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberRole memberRole = db.MemberRoles.Find(id);
            if (memberRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "F_name", memberRole.MemberID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", memberRole.RoleID);
            return View(memberRole);
        }

        // POST: MemberRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberRoleID,MemberID,RoleID")] MemberRole memberRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "F_name", memberRole.MemberID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", memberRole.RoleID);
            return View(memberRole);
        }

        // GET: MemberRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberRole memberRole = db.MemberRoles.Find(id);
            if (memberRole == null)
            {
                return HttpNotFound();
            }
            return View(memberRole);
        }

        // POST: MemberRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberRole memberRole = db.MemberRoles.Find(id);
            db.MemberRoles.Remove(memberRole);
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
