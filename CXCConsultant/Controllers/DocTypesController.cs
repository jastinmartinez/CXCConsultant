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
    public class DocTypesController : Controller
    {
        private ReceivableAccountsEntities db = new ReceivableAccountsEntities();

        // GET: DocTypes
        public ActionResult Index()
        {
            return View(db.DocType.ToList());
        }

        // GET: DocTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocType docType = db.DocType.Find(id);
            if (docType == null)
            {
                return HttpNotFound();
            }
            return View(docType);
        }

        // GET: DocTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocTypeID,DocTypeDescription,DocTypeStatus,DocTypeCountableAccount")] DocType docType)
        {
            if (ModelState.IsValid)
            {
                db.DocType.Add(docType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docType);
        }

        // GET: DocTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocType docType = db.DocType.Find(id);
            if (docType == null)
            {
                return HttpNotFound();
            }
            return View(docType);
        }

        // POST: DocTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocTypeID,DocTypeDescription,DocTypeStatus,DocTypeCountableAccount")] DocType docType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docType);
        }

        // GET: DocTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocType docType = db.DocType.Find(id);
            if (docType == null)
            {
                return HttpNotFound();
            }
            return View(docType);
        }

        // POST: DocTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocType docType = db.DocType.Find(id);
            db.DocType.Remove(docType);
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
