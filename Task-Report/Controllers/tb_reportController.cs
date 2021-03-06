﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Task_Report;

namespace Task_Report.Controllers
{
    public class tb_reportController : Controller
    {
        private Model1 db = new Model1();

        // GET: tb_report
        public ActionResult Index()
        {
            return View(db.tb_report.ToList());
        }

        //public PartialViewResult GetPaging(int? page)
        //{
        //    int pageSize = 3;
        //    int pageNumber = (page ?? 1);
        //    return PartialView("_PartialViewCustomer", tb_report.TopagedList(pageNumber, pageSize));
        //}
        //[HttpPost]
        //public ActionResult Index(HttpPostedFileBase postedFile)
        //{
        //    byte[] bytes;
        //    using (BinaryReader br = new BinaryReader(postedFile.InputStream))
        //    {
        //        bytes = br.ReadBytes(postedFile.ContentLength);
        //    }
        //    tb_report tb_report = new tb_report();
        //    tb_report.tb_report.Add(new tb_report
        //    {
        //        RequireImg = bytes
        //    });
        //    tb_report.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // GET: tb_report/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_report tb_report = db.tb_report.Find(id);
            if (tb_report == null)
            {
                return HttpNotFound();
            }
            return View(tb_report);
        }

        // GET: tb_report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_report/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserName,AgentCode,Conclution,RequireImg,ConclutionImg,Time")] tb_report tb_report, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
               
                tb_report.Time = DateTime.Now;
                db.tb_report.Add(tb_report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_report);
        }

        // GET: tb_report/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_report tb_report = db.tb_report.Find(id);
            if (tb_report == null)
            {
                return HttpNotFound();
            }
            return View(tb_report);
        }

        // POST: tb_report/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserName,AgentCode,Conclution,RequireImg,ConclutionImg,Time")] tb_report tb_report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_report);
        }

        // GET: tb_report/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_report tb_report = db.tb_report.Find(id);
            if (tb_report == null)
            {
                return HttpNotFound();
            }
            return View(tb_report);
        }

        // POST: tb_report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tb_report tb_report = db.tb_report.Find(id);
            db.tb_report.Remove(tb_report);
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
