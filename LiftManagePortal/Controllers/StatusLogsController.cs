using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LiftManagePortal.Models;

namespace LiftManagePortal.Controllers
{
    public class StatusLogsController : Controller
    {
        private DeviceDBContext db = new DeviceDBContext();

        // GET: StatusLogs
        public ActionResult Index()
        {
            return View(db.StatusLogs.ToList());
        }

        // GET: StatusLogs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusLog statusLog = db.StatusLogs.Find(id);
            if (statusLog == null)
            {
                return HttpNotFound();
            }
            return View(statusLog);
        }

        // GET: StatusLogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusLogs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusLogId,DeviceId,Status,EventEnqueuedUtcTime,CPUUsage,DiskUsage,MemoryUsage")] StatusLog statusLog)
        {
            if (ModelState.IsValid)
            {
                db.StatusLogs.Add(statusLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusLog);
        }

        // GET: StatusLogs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusLog statusLog = db.StatusLogs.Find(id);
            if (statusLog == null)
            {
                return HttpNotFound();
            }
            return View(statusLog);
        }
        // POST: StatusLogs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusLogId,DeviceId,Status,EventEnqueuedUtcTime,CPUUsage,DiskUsage,MemoryUsage,CPUUsage,DiskUsage,MemoryUsage")] StatusLog statusLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusLog);
        }

        // GET: StatusLogs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusLog statusLog = db.StatusLogs.Find(id);
            if (statusLog == null)
            {
                return HttpNotFound();
            }
            return View(statusLog);
        }

        // POST: StatusLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StatusLog statusLog = db.StatusLogs.Find(id);
            db.StatusLogs.Remove(statusLog);
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
