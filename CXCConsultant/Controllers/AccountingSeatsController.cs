using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CXCConsultant;

namespace CXCConsultant.Controllers
{
    public class AccountingSeatsController : Controller
    {
        private ReceivableAccountsEntities db = new ReceivableAccountsEntities();

        // GET: AccountingSeats
        public ActionResult Index()
        {
            var accountingSeat = db.AccountingSeat.Include(a => a.DocType).Include(a => a.Supplier);
            return View(accountingSeat.ToList());
        }

        // GET: AccountingSeats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountingSeat accountingSeat = db.AccountingSeat.Find(id);
            if (accountingSeat == null)
            {
                return HttpNotFound();
            }
            return View(accountingSeat);
        }

        // GET: AccountingSeats/Create
        public ActionResult Create()
        {
            ViewBag.DocTypeID = new SelectList(db.DocType, "DocTypeID", "DocTypeDescription");
            ViewBag.SuplierID = new SelectList(db.Supplier, "SupplierID", "SupplierName");
            return View();
        }

        // POST: AccountingSeats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountingSeatID,SuplierID,DocTypeID,AccountingSeatDate,AccountingSeatAmount,AccountingSeatStatus")] AccountingSeat accountingSeat)
        {
            if (ModelState.IsValid)
            {
                db.AccountingSeat.Add(accountingSeat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocTypeID = new SelectList(db.DocType, "DocTypeID", "DocTypeDescription", accountingSeat.DocTypeID);
            ViewBag.SuplierID = new SelectList(db.Supplier, "SupplierID", "SupplierName", accountingSeat.SuplierID);
            return View(accountingSeat);
        }

        // GET: AccountingSeats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountingSeat accountingSeat = db.AccountingSeat.Find(id);
            if (accountingSeat == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocTypeID = new SelectList(db.DocType, "DocTypeID", "DocTypeDescription", accountingSeat.DocTypeID);
            ViewBag.SuplierID = new SelectList(db.Supplier, "SupplierID", "SupplierName", accountingSeat.SuplierID);
            return View(accountingSeat);
        }

        // POST: AccountingSeats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountingSeatID,SuplierID,DocTypeID,AccountingSeatDate,AccountingSeatAmount,AccountingSeatStatus")] AccountingSeat accountingSeat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountingSeat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocTypeID = new SelectList(db.DocType, "DocTypeID", "DocTypeDescription", accountingSeat.DocTypeID);
            ViewBag.SuplierID = new SelectList(db.Supplier, "SupplierID", "SupplierName", accountingSeat.SuplierID);
            return View(accountingSeat);
        }

        // GET: AccountingSeats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountingSeat accountingSeat = db.AccountingSeat.Find(id);
            if (accountingSeat == null)
            {
                return HttpNotFound();
            }
            return View(accountingSeat);
        }

        // POST: AccountingSeats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountingSeat accountingSeat = db.AccountingSeat.Find(id);
            db.AccountingSeat.Remove(accountingSeat);
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
