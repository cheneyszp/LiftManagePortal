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
    public class DeviceStatusController : Controller
    {
        private DeviceDBContext db = new DeviceDBContext();

        // GET: DeviceStatus
        public ActionResult Index()
        {
            return View(db.DeviceStatus.ToList());
        }

        // GET: DeviceStatus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceStatus deviceStatus = db.DeviceStatus.Find(id);
            if (deviceStatus == null)
            {
                return HttpNotFound();
            }
            return View(deviceStatus);
        }

        // GET: DeviceStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceStatus/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeviceId,Status,EventEnqueuedUtcTime,CPUUsage,DiskUsage,MemoryUsage")] DeviceStatus deviceStatus)
        {
            if (ModelState.IsValid)
            {
                db.DeviceStatus.Add(deviceStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deviceStatus);
        }

        // GET: DeviceStatus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceStatus deviceStatus = db.DeviceStatus.Find(id);
            if (deviceStatus == null)
            {
                return HttpNotFound();
            }
            return View(deviceStatus);
        }

        // POST: DeviceStatus/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeviceId,Status,EventEnqueuedUtcTime,CPUUsage,DiskUsage,MemoryUsage")] DeviceStatus deviceStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deviceStatus);
        }

        // GET: DeviceStatus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceStatus deviceStatus = db.DeviceStatus.Find(id);
            if (deviceStatus == null)
            {
                return HttpNotFound();
            }
            return View(deviceStatus);
        }

        // POST: DeviceStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DeviceStatus deviceStatus = db.DeviceStatus.Find(id);
            db.DeviceStatus.Remove(deviceStatus);
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
